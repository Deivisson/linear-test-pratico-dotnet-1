﻿namespace LinearTestPratico.Infra.CrossCutting.Identity.Models
{
    public class UsuarioRespostaLoginViewModel
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UsuarioTokenViewModel UsuarioToken { get; set; }
    }
}
