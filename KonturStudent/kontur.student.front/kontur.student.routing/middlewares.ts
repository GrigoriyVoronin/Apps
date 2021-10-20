import { State } from 'router5';
import transitionPath from 'router5-transition-path';

import { IPageError } from 'kontur.student.ui';

import { RouterTransition } from './transition/Transition';
import { IRouterDoneFn, IRouterTransitionParams } from './transition/types';
import { IRouterDependencies } from './RouterService';
import { RouterErrorCodes } from './constants/RouteConstants';

const navigateToPath = (router: any, dependencies: IRouterDependencies) => async (
  toState: State,
  fromState: State,
  done: IRouterDoneFn
) => {
  const routerTransitionParams: IRouterTransitionParams = {
    fromState: fromState,
    toState: toState,
    transitionPaths: transitionPath(toState, fromState),
    done: done,
    cancel: router.cansel,
    matchURL: router.matchUrl,
  };
  const transition: RouterTransition = new RouterTransition(routerTransitionParams);
  await deactivateRoutes(transition, dependencies, toState, fromState);
  await activateRoutes(transition, dependencies, toState, fromState);
};

async function activateRoutes(
  transition: RouterTransition,
  dependencies: IRouterDependencies,
  toState: State,
  fromState: State
) {
  for (let routeName of transition.transitionPaths.toActivate) {
    const routeInstance = await getRouteInstance(routeName, dependencies);
    const toStateParams = toState.params;
    const transitionPaths = transitionPath(toState, fromState);
    transition.setStepToActivate(transitionPaths.intersection);
    if (!transition.continueExecution) {
      return true;
    }
    try {
      routeInstance.renderLoading(transition, toStateParams);
      const canActivate = routeInstance.canActivate(toState, fromState);
      if (!canActivate) {
        return false;
      }
      await routeInstance.activate(toStateParams, transition);
      if (!transition.continueExecution) {
        return true;
      }
      await routeInstance.beforeModel(toStateParams, transition);
      const instanceModel = await routeInstance.model(toStateParams, transition);
      routeInstance.afterModel(instanceModel, toStateParams, transition);
      routeInstance.renderPage({
        model: instanceModel,
        params: toStateParams,
        actions: routeInstance.actions,
      });
    } catch (exception) {
      const transitionError: IPageError = {
        name: 'Transition Error',
        code: RouterErrorCodes.JS_ERROR,
        message: exception.message,
      };
      routeInstance.renderError(transition, transitionError, toStateParams);
      throw exception;
    }
  }
}

async function deactivateRoutes(
  transition: RouterTransition,
  dependencies: IRouterDependencies,
  toState: State,
  fromState: State
) {
  for (let routeName of transition.transitionPaths.toDeactivate) {
    const routeInstance = await getRouteInstance(routeName, dependencies);
    const cadDeactivate = routeInstance.canDeactivate(toState, fromState);
    if (cadDeactivate) {
      await routeInstance.deactivate(transition);
      routeInstance.unmountPage();
      routeInstance.afterDeactivated(transition);
    }
  }
}

async function getRouteInstance(route: string, dependencies: IRouterDependencies) {
  const routeNode = dependencies.routesTree.find((e) => e.name === route);
  let routeInstance;
  if (!routeNode) {
    throw new Error();
  }

  if (routeNode.routeInstance) {
    return routeNode.routeInstance;
  } else {
    const routeClass = await routeNode.routeClass();
    routeInstance = dependencies.routeFactory(routeNode.name, routeClass);
    routeNode.routeInstance = routeInstance;
  }

  return routeInstance;
}

export default navigateToPath;
