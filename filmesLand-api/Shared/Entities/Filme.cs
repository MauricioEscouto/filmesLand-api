using filmesLand_api.Shared.Enum;
using filmesLand_api.Shared.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace filmesLand_api.Shared.Entities
{
    public class Filme
    {
        [Column("id_filme")]
        public int Id { get; set; }
        [Column("titulo")]
        public string? Titulo { get; set; }
        [Column("diretor")]
        public string? Diretor { get; set; }
        [Column("estudio")]
        public string? Estudio { get; set; }
        [Column("avaliacao")]
        public float Avaliacao { get; set; }
        [Column("isAvaliado")]
        public EnumFilmeAvaliado IsAvaliado { get; set; }

        public Filme() { }

        public Filme (FilmeRequest filmeRequest)
        {
            Titulo = filmeRequest.Titulo;  
            Diretor = filmeRequest.Diretor;
            Estudio = filmeRequest.Estudio;
        }
    }
}