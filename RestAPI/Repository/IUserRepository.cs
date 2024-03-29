﻿using RestAPI.Data.DTO;
using RestAPI.Model;

namespace RestAPI.Repository {
    public interface IUserRepository {
        // ? só para retirar o alerta.
        Users? ValidateCredentials(UsersDTO user);
        Users? ValidateCredentials(string userName);
        bool RevokeToken(string userName);
        Users? AtualizarInfoUsuario(Users user);
    }
}
