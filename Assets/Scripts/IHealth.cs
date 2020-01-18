using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public interface IHealth
    {
        void TakeDamage(float damage);
        void ChangeHealth(float delta);
    }
}
