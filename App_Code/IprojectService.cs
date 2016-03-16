using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IprojectService" in both code and config file together.
[ServiceContract]
public interface IprojectService
{
    [OperationContract]
    List<string> GetAllShows();

    [OperationContract]
    List<string> GetAllArtists();
    [OperationContract]
    List<string> GetAllvenues();

    [OperationContract]
    List<ShowInfo> GetShowsByArtist(string artistName);

    [OperationContract]
    List<ShowInfo> GetShowsByVenue(string venueName);
    
    [OperationContract]
    int venueLogin(string username, string password);
    
    [OperationContract]
    int venueRegistration(VenueRegister vr);

    [OperationContract]
    int FanLogin(string username, string password);


    [OperationContract]
    int Fangistration(FanRegister fr);  
}


[DataContract]

public class ShowInfo
{
    [DataMember]
    public string ArtistName { get; set; }
    [DataMember]
    public string ShowName { get; set; }
    [DataMember]
    public string ShowDate { get; set; }
    [DataMember]
    public string ShowTime { get; set; }

    [DataMember]
    public string TicketInfo { get; set; }

}

public class Venuelogin
{
    [DataMember]
    public int VenueLoginUserName { set; get; }

    [DataMember]
    public int VenueLoginPasswordPlain { set; get; }

}

public class VenueRegister
{
        [DataMember]
        public string venueName { set; get; }

        [DataMember]
        public string venueAddress { set; get; }

        [DataMember]
        public string venueCity { set; get; }

        [DataMember]
        public string venueState { set; get; }

        [DataMember]
        public string venueZipCode { set; get; }

        [DataMember]
        public string venuePhone { set; get; }

        [DataMember]
        public string venueEmail { set; get; }

        [DataMember]
        public string venueWebPage { set; get; }

        [DataMember]
        public int venueAgeRestriction { set; get; }

        [DataMember]
        public string venueLoginUserName { set; get; }

        [DataMember]
        public string venueLoginPasswordPlain { set; get; }
       
}

 

public class Fanlogin
{    
    [DataMember]
    public string FanLoginUserName { set; get; }

    [DataMember]
    public string FanLoginPasswordPlain { set; get; }

}

public class FanRegister 
{

    [DataMember]
    public string FanName { set; get; }

    [DataMember]
    public string FanEmail { set; get; }

    [DataMember]
    public string FanLoginUserName { set; get; }

    [DataMember]
    public string FanLoginPasswordPlain { set; get; }

}