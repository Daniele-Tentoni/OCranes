using Plugin.CloudFirestore;
using Plugin.CloudFirestore.Attributes;

namespace OCranes.Models
{
    /// <summary>
    /// Represent a single crane created by a user.
    /// </summary>
    public class Crane
    {
        /// <summary>
        /// Remote guid.
        /// </summary>
        [Id]
        public string Id { get; set; }

        [MapTo("name")]
        public string Name { get; set; }

        /// <summary>
        /// Cm di lato.
        /// </summary>
        [MapTo("cm")]
        public int Cm { get; set; }

        /// <summary>
        /// Timestamp of the creation.
        /// </summary>
        [ServerTimestamp(CanReplace = false)]
        public Timestamp CreatedAt { get; set; }

        public Crane(string name, int cm)
        {
            this.Name = name;
            this.Cm = cm;
        }
    }
}