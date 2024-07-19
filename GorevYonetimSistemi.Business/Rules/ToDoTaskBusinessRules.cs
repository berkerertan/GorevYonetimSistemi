using GorevYonetimSistemi.Business.Constants;
using GorevYonetimSistemi.Core.CrossCuttingConcerns;
using GorevYonetimSistemi.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorevYonetimSistemi.Business.Rules
{
    public class ToDoTaskBusinessRules : BaseBusinessRules
    {
        public ToDoTaskBusinessRules()
        {
            
        }
        public void TaskExists(ToDoTask task)
        {
            if (task == null)
            {
                throw new Exception(Messages.TaskNotFound);
            }
        }
    }
}
