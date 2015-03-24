using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;
using ChargingPile.DAL;

namespace ChargingPile.BLL
{
    public class MenuPowerBll : BaseBll<MenuPower>
    {
        readonly MenuPowerDal _menuPowerDal = new MenuPowerDal();
        public override bool Exist(MenuPower bean)
        {
            return _menuPowerDal.Exist(bean);
        }

        public override void Add(MenuPower bean)
        {
            _menuPowerDal.Add(bean);
        }

        public override void Del(MenuPower bean)
        {
            _menuPowerDal.Del(bean);
        }

        public override void Modify(MenuPower bean)
        {
            _menuPowerDal.Modify(bean);
        }

        public override DataTable Query(MenuPower bean)
        {
            return _menuPowerDal.Query(bean);
        }

        public override DataTable QueryByPage(MenuPower bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(MenuPower bean, int page, int rows, ref int count)
        {
            return _menuPowerDal.QueryByPage(bean, page, rows, ref count);
        }
        public DataTable QueryMenuByRole(string role)
        {
            return _menuPowerDal.QueryMenuByRole(role);
        }
    }
}
