using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "projectService" in code, svc and config file together.
public class projectService : IprojectService
{
    ShowTrackerEntities pj = new ShowTrackerEntities();

    //Lists all the shows
    public List<string> GetAllShows()
    {
        List<string> shows = new List<string>();
        var shw = from s in pj.Shows
                  select new {s.ShowName};

        foreach (var s in shw)
        {
           shows.Add(s.ShowName);
        }
        return shows;


    }
    //List all the artists
    public List<string> GetAllArtists()
    {
        List<string> artists = new List<string>();
        var art = from a in pj.Artists
            select new {a.ArtistName};

        foreach (var a in art)
        {
            artists.Add(a.ArtistName);
        }
        return artists;

        
    }

   
    //Lists all the venues
    public List<string> GetAllvenues()
    {
        List<string> venues = new List<string>();
        var ven = from v in pj.Venues
                  select new { v.VenueName };

        foreach (var v in ven)
        {
            venues.Add(v.VenueName);
        }
        return venues;
    }

 
//Lets the user select an artist and see all the shows 
    public List<ShowInfo> GetShowsByArtist(string artistName)
    {
        var shws = from s in pj.Shows
                   from d in s.ShowDetails
                   where artistName.Equals(artistName)
                   select new
                   {
                       d.Artist.ArtistName,
                       s.ShowName,
                       s.ShowTime,
                       s.ShowDate,
                       s.ShowTicketInfo

                   };
        List<ShowInfo> shows = new List<ShowInfo>();

        foreach (var sh in shws)
        {
            ShowInfo sInfo = new ShowInfo();
            sInfo.ArtistName = sh.ArtistName;
            sInfo.ShowName = sh.ShowName;
            sInfo.ShowDate = sh.ShowDate.ToShortDateString();
            sInfo.ShowTime = sh.ShowTime.ToString();
            shows.Add(sInfo);
        }

        return shows;
    }

    //   Lets the user select a venue and see all the shows
    public List<ShowInfo> GetShowsByVenue(string venueName)
    {

var shws = from s in pj.Shows
                   from d in s.ShowDetails
                   where s.Venue.VenueName.Equals(venueName)
                   select new
                   {
                       s.Venue.VenueName,
                       s.ShowName,
                       s.ShowTime,
                       s.ShowDate,
                       s.ShowTicketInfo,
                       d.Artist.ArtistName

                   };
        List<ShowInfo> shows = new List<ShowInfo>();

        foreach (var sh in shws)
        {
            ShowInfo sInfo = new ShowInfo();
            sInfo.ArtistName = sh.ArtistName;
            sInfo.ShowName = sh.ShowName;
            sInfo.ShowDate = sh.ShowDate.ToShortDateString();
            sInfo.ShowTime = sh.ShowTime.ToString();
            shows.Add(sInfo);
        }

        return shows;
    }
    //Venue Login start here

    public int venueLogin(string username, string password)
    {
        int result = pj.usp_venueLogin(username, password);
        if (result != -1)
        {
            var key = from vl in pj.Venues
                      where vl.VenueName.Equals(username)
                      select new { vl.VenueKey };
            foreach (var vl in key)
            {
                result = (int)vl.VenueKey;
            }
        }

        return result;
    }
    //int venueRegistration(VenueRegister vr);

    public int venueRegistration(VenueRegister vr)
    {

        int result = pj.usp_RegisterVenue(vr.venueName,
            vr.venueAddress, vr.venueCity, vr.venueState, vr.venueZipCode, vr.venuePhone,
            vr.venueEmail, vr.venueWebPage,
            vr.venueAgeRestriction, vr.venueLoginUserName, vr.venueLoginPasswordPlain);

        return result;
    }

    //int FanLogin(string username, string password)

    public int FanLogin(string username, string password)
    {
        int result = pj.usp_FanLogin(username, password);
        if (result != -1)
        {
            var key = from k in pj.Fans
                      where k.FanName.Equals(username)
                      select new { k.FanKey };
            foreach (var k in key)
            {
                result = (int)k.FanKey;
            }
        }

        return result;
    }
    //Fan  int Fangistration(FanRegister fr)
    public int Fangistration(FanRegister fr)
    {

        int result = pj.usp_RegisterFan(fr.FanName, fr.FanEmail, fr.FanLoginUserName, fr.FanLoginPasswordPlain);


        return result;
    }






}