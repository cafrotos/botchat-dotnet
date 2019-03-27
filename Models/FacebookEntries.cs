namespace botchat.Models
{
  public class Sender
  {
    public string id { get; set; }
  }
  public class Recipient
  {
    public string id { get; set; }
  }
  public class Message
  {
    public string text { get; set; }
  }
  public class Messaging
  {
    public Sender sender { get; set; }
    public Recipient recipient { get; set; }
    public Message message { get; set; }
  }
  public class Entry
  {
    public string id { get; set; }
    public string time { get; set; }
    public Messaging[] messaging { get; set; }
  }
  public class FacebookEntries
  {
    public Entry[] entry { get; set; }
  }
}