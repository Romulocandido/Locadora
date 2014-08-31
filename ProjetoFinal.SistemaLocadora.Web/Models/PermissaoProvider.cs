using ProjetoFinal.SistemaLocadora.BancoDados;
using ProjetoFinal.SistemaLocadora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Security;

namespace ProjetoFinal.SistemaLocadora.Web.Models
{
    public class PermissaoProvider : RoleProvider
    {
        private Contexto _contexto;

        public PermissaoProvider(Contexto contexto)
        {
            this._contexto = contexto;
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            Usuario user = (from p in this._contexto.TabelaUsuarios
                            where p.Username == username
                            select p).FirstOrDefault();
            var roles = (from t in this._contexto.TabelaPermissoes
                         where t.Id == user.Permissao.Id
                         select t.Nome).ToList();
            if (roles != null)
                return roles.ToArray();
            else
                return new string[] { }; ;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            Usuario user = (from p in this._contexto.TabelaUsuarios
                            where p.Username == username
                            select p).FirstOrDefault();
            var roles = (from t in this._contexto.TabelaPermissoes
                         where t.Id == user.Permissao.Id
                         select t.Nome).ToList();
            if (user != null)
                return roles.Any(t => t.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));
            else
                return false;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}