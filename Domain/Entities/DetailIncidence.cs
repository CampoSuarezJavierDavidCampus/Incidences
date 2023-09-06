using System.ComponentModel.DataAnnotations;
using Domain.Entities.Generics;

namespace Domain.Entities;

public class DetailIncidence:BaseEntityWithIntId{
        public string? Description { get; set; }

        public int IdIncidenceFk { get; set; }
        public Incidence? Incidence { get; set; }

        public int IdPeripheralFk { get; set; }
        public ICollection<Peripheral>? Peripherals { get; set; }

        public int IdTypeIncidenceFk { get; set; }
        public TypeIncidence? TypeIncidence { get; set; }

        public int IdLevelIncidenceFk { get; set; }
        public LevelIncidence? LevelOfIncidence { get; set; }

        public int IdStateFk { get; set; }
        public State? State { get; set; }
}