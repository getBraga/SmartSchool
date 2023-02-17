﻿namespace SmartSchool.WebAPI.Models
{
    public class Curso
    {
        public Curso()
        {

        }
        public Curso(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Disciplina> Disciplinas { get; set; }

     
    }
}
