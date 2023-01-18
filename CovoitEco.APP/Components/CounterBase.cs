using CovoitEco.APP.Service.Vehicule.Queries;
using Microsoft.AspNetCore.Components;

namespace CovoitEco.APP.Components
{
    public class CounterBase : ComponentBase
    {

        protected int currentCount = 0;

        [Parameter]
        public int IncrementAmount { get; set; } = 1;


        protected void IncrementCount()
        {
            currentCount += IncrementAmount;
        }
    
}
}
