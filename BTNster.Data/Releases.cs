using BTNster.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTNster.Data
{
    public static class Releases
    {
        public static void SaveRelease(Release ircRelease)
        {
            using (BTNsterEntities db = new BTNsterEntities())
            {
                BTNster.Data.Release release = new Release()
                {
                    RawIRCAnnounce = ircRelease.RawIRCAnnounce,
                    RawIRCAnnounceDate = ircRelease.RawIRCAnnounceDate,
                    ReleaseID = ircRelease.ReleaseID
                };

                db.Releases.Add(release);
            }
        }

        public static BTNRelease GetRelease(long releaseID)
        {
            BTNRelease release = new BTNRelease();
            return release;
        }
    }
}
