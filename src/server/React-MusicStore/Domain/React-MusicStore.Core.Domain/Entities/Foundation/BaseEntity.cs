using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using ReactMusicStore.Core.Domain.Entities.Identity;
using ReactMusicStore.Core.Domain.Interfaces.Foundation;

namespace ReactMusicStore.Core.Domain.Entities.Foundation
{
    public abstract class BaseEntity : IBaseEntity
    {
	    #region ||---BaseData---||
	    [Key]
	    public int Id { get; set; }

		public DateTime? CreatedOn { get; set; }
	    public DateTime? ModifiedOn { get; set; }

	    public int? CreatedById { get; set; }
	    public int? ModifiedById { get; set; }

	    [ForeignKey("CreatedById")]
	    public virtual UserAccount CreatedBy { get; set; }

	    [ForeignKey("ModifiedById")]
	    public virtual UserAccount ModifiedBy { get; set; }


	    #endregion

	    #region ||---Tools---||

	    public override bool Equals(object obj)
	    {
		    return Equals(obj as BaseEntity);
	    }

	    private static bool IsTransient(BaseEntity obj)
	    {
		    return obj != null && Equals(obj.Id, default(int));
	    }

	    //private Type GetUnproxiedType()
	    //{
	    //    return GetType();
	    //}

	    public virtual bool Equals(BaseEntity other)
	    {
		    if (other == null)
			    return false;

		    if (ReferenceEquals(this, other))
			    return true;

		    if (!IsTransient(this) &&
		        !IsTransient(other) &&
		        Equals(Id, other.Id))
		    {
			    var otherType = other.GetUnproxiedType();
			    var thisType = GetUnproxiedType();
			    return thisType.IsAssignableFrom(otherType) ||
			           otherType.IsAssignableFrom(thisType);
		    }

		    return false;
	    }

	    public override int GetHashCode()
	    {
		    if (Equals(Id, default(int)))
			    return base.GetHashCode();
		    return Id.GetHashCode();
	    }

	    public static bool operator ==(BaseEntity x, BaseEntity y)
	    {
		    return Equals(x, y);
	    }

	    public static bool operator !=(BaseEntity x, BaseEntity y)
	    {
		    return !(x == y);
	    }

	    #endregion

	    public virtual bool IsTransientRecord()
	    {
		    return Id == 0;
	    }
	    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
	    public Type GetUnproxiedType()
	    {
		    var t = GetType();
		    if (t.AssemblyQualifiedName.StartsWith("System.Data.Entity."))
		    {
			    // it's a proxied type
			    t = t.BaseType;
		    }
		    return t;
	    }
	}
}