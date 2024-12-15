using System;
using System.Collections.Generic;

namespace ASPCoreWebAPICrud.Models;

public partial class Emp
{
    public int Empno { get; set; }

    public string? Ename { get; set; }

    public string? Job { get; set; }

    public int? Mgr { get; set; }

    public DateOnly? HireDate { get; set; }

    public decimal? Salary { get; set; }

    public decimal? Comm { get; set; }

    public int? Deptno { get; set; }

    public virtual Dept? DeptnoNavigation { get; set; }
}
