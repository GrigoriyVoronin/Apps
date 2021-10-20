#region using

using System;
using System.Linq;
using JetBrains.Annotations;
using Kontur.Rest.Filter;

#endregion

namespace KSRepositories.Repositories
{
    public static class FilterExtensions
    {
        [NotNull]
        public static string ToNpgSqlString([NotNull] this IFilter filter)
        {
            return filter switch
            {
                LogicalFilter logicalFilter => logicalFilter.ToNpgSqlString(),
                ComparisonFilter comparisonFilter => comparisonFilter.ToNpgSqlString(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        [NotNull]
        public static string ToNpgSqlString([NotNull] this ComparisonFilter filter)
        {
            return filter.Operator switch
            {
                ComparisonOperator.Equal => filter.Field.GetFieldComparisonString("="),
                ComparisonOperator.NotEqual => filter.Field.GetFieldComparisonString("!="),
                ComparisonOperator.Similar => filter.Field.GetFieldComparisonString("SIMILAR TO"),
                ComparisonOperator.NotSimilar => filter.Field.GetFieldComparisonString("NOT SIMILAR TO"),
                ComparisonOperator.More => filter.Field.GetFieldComparisonString(">"),
                ComparisonOperator.Less => filter.Field.GetFieldComparisonString("<"),
                ComparisonOperator.LessOrEqual => filter.Field.GetFieldComparisonString("<="),
                ComparisonOperator.MoreOrEqual => filter.Field.GetFieldComparisonString(">="),
                ComparisonOperator.Substring => filter.Field.GetFieldComparisonString("~*"),
                ComparisonOperator.NotSubstring => filter.Field.GetFieldComparisonString("!~*"),
                ComparisonOperator.RegExp => filter.Field.GetFieldComparisonString("SIMILAR TO"),
                ComparisonOperator.ContainsInList => throw new NotSupportedException(
                    $"{ComparisonOperator.ContainsInList}"),
                ComparisonOperator.NotContainsInList => throw new NotSupportedException(
                    $"{ComparisonOperator.NotContainsInList}"),
                ComparisonOperator.NotPrefix => throw new NotSupportedException($"{ComparisonOperator.NotPrefix}"),
                ComparisonOperator.Prefix => throw new NotSupportedException($"{ComparisonOperator.Prefix}"),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        [NotNull]
        public static string ToNpgSqlString([NotNull] this LogicalFilter filter)
        {
            var separator = $" {filter.Operator} ";
            var filters = filter.Filters.Select(x => x.ToNpgSqlString());
            return $"({string.Join(separator, filters)})";
        }

        [NotNull]
        private static string GetFieldComparisonString([NotNull] this FilterField field, string stringOperator)
        {
            return $"(\"{field.Name}\" {stringOperator} '{field.Value}')";
        }
    }
}