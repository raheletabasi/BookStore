using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Utiliy;

public static class StringHelper
{
    public static string FixText(this string text) => text?.Trim().Replace(" ", "");
}
