/*
 * Created by SharpDevelop.
 * User: smke-ing3
 * Date: 04.03.2016
 * Time: 13:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace PiramidaAnalize
{
	/// <summary>
	/// Лаконичное и исчерпывающее описание папки
	/// </summary>
	public struct Folder : IEquatable<Folder>
	{
		public long FolderID;
		public long ParentFolderID;
		public string FolderName;
		#region ToString, Equals and GetHashCode implementation
		// The code in this region is useful if you want to use this structure in collections.
		// If you don't need it, you can just remove the region and the ": IEquatable<Folder>" declaration.
		
		public override bool Equals(object obj)
		{
			if (obj is Folder)
				return Equals((Folder)obj); // use Equals method below
			else
				return false;
		}
		
		public bool Equals(Folder other)
		{
			// add comparisions for all members here
			return this.FolderID == other.FolderID;
		}
		
		public override int GetHashCode()
		{
			// combine the hash codes of all members here (e.g. with XOR operator ^)
			return FolderID.GetHashCode();
		}
		
		public static bool operator ==(Folder left, Folder right)
		{
            return left.FolderID == right.FolderID;
		}
		
		public static bool operator !=(Folder left, Folder right)
		{
            return left.FolderID != right.FolderID;
		}

        public override string ToString()
        {
            return this.FolderName;
        }
        #endregion
    }

    /// <summary>
    /// Лаконичное и исчерпывающее описание устройства
    /// </summary>
    public struct Device : IEquatable<Device>
    {        
        public long DeviceID;
        public long DeviceCode;
        public string DeviceName;
        public long FolderID;
        #region ToString, Equals and GetHashCode implementation
        // The code in this region is useful if you want to use this structure in collections.
        // If you don't need it, you can just remove the region and the ": IEquatable<Sensor>" declaration.

        public override bool Equals(object obj)
        {
            if (obj is Device)
                return Equals((Device)obj); // use Equals method below
            else
                return false;
        }

        public bool Equals(Device other)
        {
            // add comparisions for all members here
            return this.DeviceID == other.DeviceID;
        }

        public override int GetHashCode()
        {
            // combine the hash codes of all members here (e.g. with XOR operator ^)
            return DeviceID.GetHashCode();
        }

        public static bool operator ==(Device left, Device right)
        {
            return left.DeviceID == right.DeviceID;
        }

        public static bool operator !=(Device left, Device right)
        {
            return left.DeviceID != right.DeviceID;
        }

        public override string ToString()
        {
            return this.DeviceName;
        }
        #endregion
    }

    /// <summary>
	/// Лаконичное и исчерпывающее описание канала учета
	/// </summary>
	public struct Sensor : IEquatable<Sensor>
    {
        public long SensorID;
        public long SensorCode;
        public long DeviceID;
        public long DeviceCode;
        public string DeviceName;
        public long SubdeviceID;
        public string SensorName;
        #region ToString, Equals and GetHashCode implementation
        // The code in this region is useful if you want to use this structure in collections.
        // If you don't need it, you can just remove the region and the ": IEquatable<Sensor>" declaration.

        public override bool Equals(object obj)
        {
            if (obj is Sensor)
                return Equals((Sensor)obj); // use Equals method below
            else
                return false;
        }

        public bool Equals(Sensor other)
        {
            // add comparisions for all members here
            return this.SensorID == other.SensorID;
        }

        public override int GetHashCode()
        {
            // combine the hash codes of all members here (e.g. with XOR operator ^)
            return SensorID.GetHashCode();
        }

        public static bool operator ==(Sensor left, Sensor right)
        {
            return left.SensorID == right.SensorID;
        }

        public static bool operator !=(Sensor left, Sensor right)
        {
            return left.SensorID != right.SensorID;
        }

        public override string ToString()
        {
            return string.Format("{0}; {1}", this.DeviceName, this.SensorName);
        }
        #endregion
    }
}
