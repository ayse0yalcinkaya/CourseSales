﻿namespace CourseSales.Repositories
{
    public class BaseEntity<T>
    {
        public T Id { get; set; } = default!;
    }
}
