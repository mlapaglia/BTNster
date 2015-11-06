using System.Linq;

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
            using (BTNsterEntities db = new BTNsterEntities())
            {
                var release = db.BTNReleases.Where(x => x.ReleaseID == releaseID).FirstOrDefault();

                if (release != null)
                {
                    return new BTNRelease()
                    {
                        Episode = release.Episode,
                        ReleaseID = release.ReleaseID,
                        Season = release.Season,
                        Series = release.Series
                    };
                }

                return release;
            }
        }
    }
}
