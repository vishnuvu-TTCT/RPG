using System.Text.Json.Serialization;

namespace RPG.Models
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum RpgClass
	{
		Duelist =1,
		Initiator =2,
		Controller =3,
		Sentinal=4

	}
}