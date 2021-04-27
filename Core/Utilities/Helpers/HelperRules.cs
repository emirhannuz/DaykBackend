using Core.Utilities.Results;
using System;

namespace Core.Utilities.Helpers
{
    public class HelperRules
    {
        public static IResult Run(params IResult[] logics)
        {

            foreach (var logic in logics)
            {
                if (!logic.Success) { return logic; }
            }
            return null;
        }

        internal object Run(IDataResult<string> dataResult)
        {
            throw new NotImplementedException();
        }
    }
}
