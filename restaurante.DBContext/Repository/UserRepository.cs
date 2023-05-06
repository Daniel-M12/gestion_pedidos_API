using System;
using System.Linq.Expressions;
using DBEntity;

namespace DBContext
{
    public class UserRepository : IUserRepository
    {
        RestauranteContext context;

        public UserRepository(RestauranteContext dbcontext)
        {
            context = dbcontext;
        }

        public EntityBaseResponse Insert(EntityUser user)
        {
            var response = new EntityBaseResponse();

            try
            {
                var inserted = context.Add<EntityUser>(user);
                context.SaveChanges();

                if(inserted != null)
                {
                    response.isSuccess = true;
                    response.errorCode = "0000";
                    response.errorMessage = "";
                    response.data = inserted;
                }
                else
                {
                    response.isSuccess = false;
                    response.errorCode = "0000";
                    response.errorMessage = "";
                    response.data = null;
                }
                
            }
            catch(Exception e)
            {
                response.isSuccess = false;
                response.errorCode = "0001";
                response.errorMessage = e.Message;
                response.data = null;
            }

            return response;
        }

        public EntityBaseResponse Login(EntityLogin login)
        {

            var response = new EntityBaseResponse();

            try
            {
                var user = context.Set<EntityUser>()
                .Where(p => p.login_usuario == login.uid &&
                            p.password == login.pwd).FirstOrDefault();


                var userResponse = new EntityLoginResponse();

                userResponse.id_usuario = user.id_usuario;
                userResponse.rol = user.rol;
                userResponse.dni = user.dni;
                userResponse.token = "";


                if (user != null)
                {
                    response.isSuccess = true;
                    response.errorCode = "0000";
                    response.errorMessage = "";
                    response.data = userResponse;
                }
                else
                {
                    response.isSuccess = false;
                    response.errorCode = "0000";
                    response.errorMessage = "";
                    response.data = null;
                }

            }
            catch (Exception e)
            {
                response.isSuccess = false;
                response.errorCode = "0001";
                response.errorMessage = e.Message;
                response.data = null;
            }

            return response;
        }
    }
}

