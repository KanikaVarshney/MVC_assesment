﻿using TrainingManagement.Context;
using TrainingManagement.Models;

namespace TrainingManagement.Repository
{
    public class BatchRepository:InterfaceBatch
    {
        TrainingDbContext _db;
        public BatchRepository(TrainingDbContext db)
        {
            _db = db;
        }

        //public List<Batch> GetBatches()
        //{
        //    return _db.Batches.ToList();
        //}

        //public Batch GetBatchById(int id)
        //{
        //    return _db.Batches.FirstOrDefault(x => x.BatchId == id);
        //}


        //public Batch Create(Batch batch)
        //{
        //    _db.Batches.Add(batch);
        //    _db.SaveChanges();
        //    return batch;
        //}

        public Batch Create(Batch batch)
        {
            _db.Batches.Add(batch);
            _db.SaveChanges();
            return batch;
        }





        public int Edit(int id, Batch batch)
        {
            Batch obj = GetBatchById(id);
            if (obj != null)
            {
                foreach (Batch temp in _db.Batches)
                {
                    if (temp.BatchId == id)
                    {
                        temp.StartDate = batch.StartDate;
                        temp.BatchName = batch.BatchName;
                        temp.Trainer = batch.Trainer;
                    }
                }
                _db.SaveChanges();
            }
            return 1;
        }
        public Batch GetBatchById(int id)
        {
            return _db.Batches.FirstOrDefault(x => x.BatchId == id);
        }



        public List<BatchViewModel> GetBatches()
        {
            var list = (
            from batch in _db.Batches
            join course in _db.Courses
            on batch.Course.CourseId
            equals course.CourseId
            select new BatchViewModel
            {
                Id = batch.BatchId,
                BatchName = batch.BatchName,
                Trainer = batch.Trainer,
                CourseName = course.CourseName,
                Description = course.CourseDescription,
                StartDate = batch.StartDate,
            }).ToList();
            return list;
            //return _db.Batchs.ToList();
        }



    }
}
