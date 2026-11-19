# Código: aguinaldo + tasa de cambio (`feat/aguinaldo-entities-clean`)

Rama: `feat/aguinaldo-entities-clean`  
Sin migración EF / API en esta rama.

---

## ChristmasBonusPeriod.cs

```csharp
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class ChristmasBonusPeriod : BaseEntity<Guid> 
    {
        public Guid CompanyId { get; set; }

        public virtual Company Company { get; set; } = default!;

        public int EndYear { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public ChristmasBonusPeriodStatus Status { get; set; }

        public virtual ICollection<ChristmasBonusAccrual> Accruals { get; set; } = [];

        public virtual ICollection<ChristmasBonusAdvance> Advances { get; set; } = [];

        public virtual ICollection<ChristmasBonusSettlement> Settlements { get; set; } = [];
    }
}
```

---

## ChristmasBonusAccrual.cs

```csharp
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class ChristmasBonusAccrual : BaseEntity<Guid>
    {
        public Guid ChristmasBonusPeriodId { get; set; } // a que periodo esta referenciado
        public virtual ChristmasBonusPeriod ChristmasBonusPeriod { get; set; } = default!;


        public Guid CollaboratorId { get; set; }
        public virtual Collaborator Collaborator { get; set; } = default!;

        public Guid PayrollId { get; set; }
        public virtual Payroll Payroll { get; set; } = default!;


        public int AccrualYear { get; set; } //year
        public int AccrualMonth { get; set; } //month

        public DateOnly CoveredFrom { get; set; } //que cobertura como tal tiene el registro
        public DateOnly CoveredTo { get; set; }

        public decimal EligibleDays { get; set; }//Cantidad de días que generaron derecho.

         public decimal ChristmasBonusDays { get; set; } // dias generados aqui

        public decimal BaseSalarySnapshot { get; set; } // hacemos tracking de que salario se utilizo por si cambia en algun momento

        public decimal AccruedAmount { get; set; } // money acumulado

        public decimal? AccruedAmountInDollars { get; set; } //monto en dolares

    }
}
```

---

## ChristmasBonusAdvance.cs

```csharp
using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class ChristmasBonusAdvance : BaseEntity<Guid>
    {
        public Guid ChristmasBonusPeriodId { get; set; }

        public virtual ChristmasBonusPeriod ChristmasBonusPeriod { get; set; } = default!;

        public Guid CollaboratorId { get; set; }

        public virtual Collaborator Collaborator { get; set; } = default!;

        public Guid? PayrollId { get; set; }

        public virtual Payroll? Payroll { get; set; }

        public Currency Currency { get; set; }

        public decimal Amount { get; set; }

        public ChristmasBonusAdvanceStatus Status { get; set; }

        public DateOnly RequestedAt { get; set; }

        public Guid? RequestedById { get; set; }

        public virtual User? RequestedBy { get; set; }

        public DateOnly? ApprovedAt { get; set; }

        public Guid? ApprovedById { get; set; }

        public virtual User? ApprovedBy { get; set; }

        public DateOnly? PaidAt { get; set; }

        public Guid? PaidById { get; set; }

        public virtual User? PaidBy { get; set; }

        public DateOnly? CancelledAt { get; set; }

        public Guid? CancelledById { get; set; }

        public virtual User? CancelledBy { get; set; }

        public string? CancellationReason { get; set; }
    }
}
```

---

## ChristmasBonusSettlement.cs

```csharp
using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class ChristmasBonusSettlement : BaseEntity<Guid>
    {
        public Guid ChristmasBonusPeriodId { get; set; }

        public virtual ChristmasBonusPeriod ChristmasBonusPeriod { get; set; }
            = default!;

        public Guid CollaboratorId { get; set; }

        public virtual Collaborator Collaborator { get; set; }
            = default!;

        public Guid? PayrollId { get; set; }

        public virtual Payroll? Payroll { get; set; }

        public ChristmasBonusSettlementType Type { get; set; }

        public ChristmasBonusSettlementStatus Status { get; set; }

        public DateOnly CutoffDate { get; set; } //fecha hasta la cual se realizo el cálculo

        public SalaryType SalaryTypeSnapshot { get; set; }

        public decimal ReferenceSalary { get; set; } // Cual salario fue referenciado

        public decimal EligibleDays { get; set; } //Cuantos dias elegibles dentro del ciclo como tal

        public decimal ChristmasBonusDays { get; set; } // dias equivalentes

        public decimal GrossEntitlement { get; set; } // aguinaldo total antes de posibles adelantos

        public decimal AdvancesPaid { get; set; } // suma de los posibles adelantos pagados

        public decimal ChildSupportWithholding { get; set; } // aqui se toma en cuenta la posible retencion alimenticia a aguinaldo

        public decimal AmountToPay { get; set; } //cantidad a pagarj

        public decimal? AmountToPayInDollars { get; set; }


        public DateOnly? PaidAt { get; set; }

        public Guid? PaidById { get; set; }

        public virtual User? PaidBy { get; set; }

    }
}
```

---

## ExchangeRateHistory.cs (`Entities/Catalogs`)

```csharp
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{
    // Representa una entidad que registrar historial de tasa de cambio.
    public class ExchangeRateHistory : BaseEntity<Guid>
    {
        public Currency Currency { get; set; }

        public decimal Rate { get; set; }

        public DateOnly EffectiveFrom { get; set; }

        public DateOnly? EffectiveTo { get; set; }
    }
}
```

---

## Enums

### ChristmasBonusPeriodStatus

```csharp
namespace ERP.Core.Database.Domain.Enums
{
    //Aqui se esta definiendo los posibles estados de un período anual de aguinaldo.
    public enum ChristmasBonusPeriodStatus
    {
        Active = 1, //período está actualmente acumulando aguinaldo.
        Completed = 2, //período terminó, pero todavía podría estar pendiente de el pago completo.
        Settled = 3 //período ya fue liquidado.
    }
}
```

### ChristmasBonusAdvanceStatus

```csharp
namespace ERP.Core.Database.Domain.Enums
{
    //aqui el enum para identificar el estado de adelanto de aguinaldo en payroll
    public enum ChristmasBonusAdvanceStatus
    {
        Pending = 1,
        Approved = 2,
        Paid = 3,
        Cancelled = 4,
    }
}
```

### ChristmasBonusSettlementStatus

```csharp
namespace ERP.Core.Database.Domain.Enums
{
    //este enum de aqui para representar el  cálculo definitivo, no la acumulación mensual del aguinaldo. 
    public enum ChristmasBonusSettlementStatus
    {
        Calculated = 1, // la fase inicial de estar en estado calculado
        Paid = 2, // aqui la  fase de haber estado pagado 
    }
}
```

### ChristmasBonusSettlementType

```csharp
namespace ERP.Core.Database.Domain.Enums
{
   public enum ChristmasBonusSettlementType
    {
        Annual = 1, //calculo cotidiano de Pago normal del aguinaldo.
        EmploymentTermination = 2, // calculo proporcional porque terminó la relación laboral.
    } 
}
```

### PayrollType (cambio)

```csharp
namespace ERP.Core.Database.Domain.Enums
{
    public enum PayrollType
    {
        None = 0,
        Ordinary = 1,
        Provided = 2,
        ProfessionalServices = 3,
        ChristmasBonus = 4 // separando responsabilidad pago de nomina de pago aguinaldo
    }
}
```

---

## Cambios en Collaborator.cs (navegaciones)

```csharp
        // aguinaldo
        public virtual ICollection<ChristmasBonusAccrual> ChristmasBonusAccruals { get; set; } = [];
        
        public virtual ICollection<ChristmasBonusAdvance> ChristmasBonusAdvances { get; set; } = [];

        public virtual ICollection<ChristmasBonusSettlement> ChristmasBonusSettlements { get; set; } = [];
```

---

## Cambios en Payroll.cs

```csharp
        // Cierre de payroll
        public DateOnly? ClosedAt { get; set; }

        public Guid? ClosedBy { get; set; }

        public virtual User? ClosedByUser { get; set; }

        // ...

        public virtual ICollection<ChristmasBonusAccrual> ChristmasBonusAccruals { get; set; } = [];

        public virtual ICollection<ChristmasBonusAdvance> ChristmasBonusAdvances { get; set; } = [];

        public virtual ICollection<ChristmasBonusSettlement> ChristmasBonusSettlements { get; set; } = [];
```

---

## Application — interfaces de repositorios

### IChristmasBonusPeriodRepository.cs

```csharp
using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IChristmasBonusPeriodRepository : IRepository<ChristmasBonusPeriod>
    {
        Task<ChristmasBonusPeriod> RegisterChristmasBonusPeriod(ChristmasBonusPeriod period);

        Task<ChristmasBonusPeriod?> GetChristmasBonusPeriodByCompanyAndDate(Guid companyId, DateOnly date);

        Task<ChristmasBonusPeriod?> GetChristmasBonusPeriodByCompanyAndEndYear(Guid companyId, int endYear);
    }
}
```

### IChristmasBonusAccrualRepository.cs

```csharp
using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IChristmasBonusAccrualRepository
        : IRepository<ChristmasBonusAccrual>
    {
        Task<ChristmasBonusAccrual> RegisterChristmasBonusAccrual(
            ChristmasBonusAccrual accrual);

        Task<ChristmasBonusAccrual?> GetChristmasBonusAccrualMonthly(
            Guid collaboratorId,
            Guid christmasBonusPeriodId,
            int year,
            int month);

        Task<List<ChristmasBonusAccrual>> GetChristmasBonusAccrualsByPeriod(
            Guid collaboratorId,
            Guid christmasBonusPeriodId);
    }
}
```

### IChristmasBonusAdvanceRepository.cs

```csharp
using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IChristmasBonusAdvanceRepository : IRepository<ChristmasBonusAdvance>
    {
        Task<ChristmasBonusAdvance> RegisterChristmasBonusAdvance(ChristmasBonusAdvance bonusAdvance);

        Task<List<ChristmasBonusAdvance>> GetPaidAdvances(Guid collaboratorId, Guid christmasBonusPeriodId);
    }
}
```

### IChristmasBonusSettlementRepository.cs

```csharp
using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IChristmasBonusSettlementRepository : IRepository<ChristmasBonusSettlement>
    {
        Task<ChristmasBonusSettlement> RegisterChristmasBonusSettlement(ChristmasBonusSettlement settlement);

        Task<ChristmasBonusSettlement?> GetChristmasBonusSettlementByCollaboratorAndPeriod(
            Guid collaboratorId,
            Guid christmasBonusPeriodId);
    }
}
```

### IExchangeRateHistoryRepository.cs

```csharp
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs
{
    public interface IExchangeRateHistoryRepository : IRepository<ExchangeRateHistory>
    {
        Task<ExchangeRateHistory> RegisterExchangeRateHistory(ExchangeRateHistory exchangeRateHistory);

        Task<ExchangeRateHistory?> GetExchangeRateByDate(Currency currency, DateOnly date);

        Task<List<ExchangeRateHistory>> GetExchangeRateHistoryByCurrency(Currency currency);
    }
}
```

---

## Application — cambios en IUnitOfWork.cs

```csharp
        // región Catálogos
        IExchangeRateHistoryRepository ExchangeRateHistories { get; }

        // región Aguinaldo
        IChristmasBonusPeriodRepository ChristmasBonusPeriods { get; }

        IChristmasBonusAccrualRepository ChristmasBonusAccruals { get; }

        IChristmasBonusAdvanceRepository ChristmasBonusAdvances { get; }

        IChristmasBonusSettlementRepository ChristmasBonusSettlements { get; }
```
