namespace SpiderNetApi.Models;

public record MissaoAranha(
    int Id, 
    string VilaoEnfrentado, 
    string Localizacao, 
    int NivelPerigo, 
    bool Resolvido
);