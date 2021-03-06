﻿using Common.Abstract;

namespace Pattern.Details
{
    /// <summary>
    /// Базовый билдер зданий
    /// </summary>
    public abstract class BuilderBase : IBuilder<Building>
    {
        protected BuilderBase(string name)
        {
            Building = new Building();
            Building.DisplayName = name;
        }
        /// <summary>
        /// Строим крышу
        /// </summary>
        public abstract void BuildRoof();
        /// <summary>
        /// Строим стены
        /// </summary>
        public abstract void BuildWalls();
        /// <summary>
        /// Строим пол 
        /// </summary>
        public abstract void BuildFloor();
        /// <summary>
        /// Возращает здание 
        /// </summary>
        /// <returns></returns>
        public abstract Building CreateBuilding();

        /// <summary>
        /// Хранит экземпляр постройки
        /// </summary>
        protected Building Building { get; private set; }
    }

    public interface IBuilder<T> where T : Base
    {
        /// <summary>
        /// Строим крышу
        /// </summary>
        void BuildRoof();
        /// <summary>
        /// Строим стены
        /// </summary>
        void BuildWalls();
        /// <summary>
        /// Строим пол 
        /// </summary>
        void BuildFloor();
        /// <summary>
        /// Возращает здание 
        /// </summary>
        /// <returns></returns>
        T CreateBuilding();
    }
}
