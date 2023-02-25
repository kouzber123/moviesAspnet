using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tomtest.Data.Exception
{
  public interface IResult
  {
    bool Success { get; }
    string Message { get; }
  }
}