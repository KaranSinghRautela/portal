using portal.Models;
using portal.Models.Leave;

namespace portal.Services
{
    public interface LeaveService
    {
        List<Leave> GetLeaves();

        Leave CreateLeave(Leave leave);

        int EditLeave(int id, Leave leave);

        int DeleteLeave(int id);

        Leave GetLeaveById(int id);
    }

    public class LeaveRepo : LeaveService
    {

        ApplicationDbContext _db;
        public LeaveRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public Leave CreateLeave(Leave leave)
        {
            _db.Leaves.Add(leave);
            _db.SaveChanges();
            return leave;
        }

        public int DeleteLeave(int id)
        {
            Leave Obj = GetLeaveById(id);
            if (Obj != null)
            {
                _db.Leaves.Remove(Obj);
                _db.SaveChanges();
                return 0;

            }
            return 1;
        }

        public int EditLeave(int id, Leave leave)
        {
            Leave Obj = GetLeaveById(id);
            if (Obj != null)
            {
                foreach (Leave temp in _db.Leaves)
                {
                    if (temp.LeaveId == id)
                    {
                        temp.Purpose = leave.Purpose;
                        temp.DateFrom = leave.DateFrom;
                        temp.DateTo = leave.DateTo;

                    }
                }
                _db.SaveChanges();
                return 0;
            }
            return 1;
        }

        public Leave GetLeaveById(int id)
        {
            return _db.Leaves.FirstOrDefault(x => x.LeaveId == id);
        }

        public List<Leave> GetLeaves()
        {
            return _db.Leaves.ToList();
        }
    }
}
