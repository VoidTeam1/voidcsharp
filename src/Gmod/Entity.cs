using System;

#pragma warning disable 0626

namespace VoidSharp {

    public class Entity
    {
        public dynamic GmodEntity { get; }

        public Entity(dynamic entity)
        {
            GmodEntity = entity;
        }
        
        public Entity(dynamic entity, bool sig)
        {
            GmodEntity = entity;
        }
        
        public Entity(string className)
        {
            GmodEntity = Globals.Ents.Create(className);
        }

        public bool IsPlayer => GmodEntity.IsPlayer();
        public bool IsValid => GmodEntity.IsValid();
        public string Class => GmodEntity.GetClass();

        public string Model
        {
            get => GmodEntity.GetModel();
            set => GmodEntity.SetModel(value);
        }

        public Vector Pos
        {
            get => GmodEntity.GetPos();
            set => GmodEntity.SetPos(value);
        }

        public Color Color
        {
            get => VoidSharp.Color.FromGmodColor(GmodEntity.GetColor());
            set => GmodEntity.SetColor(value.ToGmodColor());
        }


        public static Entity FromGmod(object gmodEntity)
        {
            return new Entity(gmodEntity);
        }
    }
}