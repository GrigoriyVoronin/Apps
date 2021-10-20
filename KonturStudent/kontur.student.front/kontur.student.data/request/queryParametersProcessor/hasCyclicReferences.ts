export function hasCyclicReferences(target: Record<string, any>) {
  const seenObjects = new Set<object>();

  function detect(objToCheck: Record<string, any>) {
    if (objToCheck && typeof objToCheck === 'object') {
      if (seenObjects.has(objToCheck)) {
        return true;
      }
      seenObjects.add(objToCheck);
      for (const key in objToCheck) {
        if (objToCheck.hasOwnProperty(key) && detect(objToCheck[key])) {
          return true;
        }
      }
      seenObjects.delete(objToCheck);
    }
    return false;
  }

  return detect(target);
}
