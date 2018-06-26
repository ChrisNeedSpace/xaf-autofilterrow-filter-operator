using System;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace TestProject17_2.Module.BusinessObjects
{
  [Persistent]
  public abstract class SalesTransactionShippableHeaderBase : BaseObject
  { 
    public SalesTransactionShippableHeaderBase(Session session)
        : base(session)
    {
    }

    private string _documentNumber;
    [AutoFilterRowCondition(AutoFilterRowCondition.BeginsWith)]
    [VisibleInListView(true)]
    public string DocumentNumber
    {
      get { return _documentNumber; }
      set { SetPropertyValue(nameof(DocumentNumber), ref _documentNumber, value); }
    }
    
    private static Random random = new Random(DateTime.Now.Millisecond);

    protected int GenerateSomeSillyNumber()
    {
      return random.Next(10000);
    }
  }
}