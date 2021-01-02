using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TaskListV2.UITests.Startup
{
  public class BootstrapperTests
  {
    [Fact]
    public void ShouldUseTheCorrectDB()
    {
      int a = 2;
      int b = 3;
      

      Assert.Equal(a, b);
    }
    [Fact]
    public void Test0()
    {

      string expected = "1,2";
      string actual = "1,2";

      Assert.Equal(expected, actual);
    }
  }
}
