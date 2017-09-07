/*
 * Created by SharpDevelop.
 * User: smke-ing3
 * Date: 03.03.2016
 * Time: 15:43
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using Microsoft.SqlServer.Server;

namespace PiramidaAnalize
{
	/// <summary>
	/// This class handles all the interaction between the application
    /// and the Piramida2000 database
	/// </summary>
	public class DataProvider
	{
        public struct DataPoint
        {
            public DateTime TimeStamp;
            public double DataEntry;
        }

        private string connectionString;
				
		public DataProvider()
		{
            database st = new PiramidaAnalize.database();
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = st.Server;
            cs.UserID = st.UID;
            cs.Password = st.Password;
            cs.InitialCatalog = st.Database;
            connectionString = cs.ToString();
		}
		
		/// <summary>
		/// Fills the TreeView control with the data from Piramida2000 database
        /// The data consists of hyerarchical list of all folders, devices and sensors
        /// in the database.
		/// </summary>
		/// <param name="tree">Reference to the TreeView control</param>
        public void PopulateTree(TreeView tree, ImageList imList = null)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdSensors;
            SqlDataReader drSensors;
            if (imList != null) tree.ImageList = imList;
            TreeNode resultNode;
            cn.Open();
            cmdSensors = cn.CreateCommand();
            cmdSensors.CommandText = "select [key],parent,[name] from dbo.AllObjects order by orderby, " +
                "parent, convert(int,substring([key],2,16))";
            drSensors = cmdSensors.ExecuteReader();
            while (drSensors.Read())
            {
                if (drSensors.GetString(0) == "F0")
                {
                    resultNode = tree.Nodes.Add(drSensors.GetString(0), drSensors.GetString(2));
                    resultNode.Tag = drSensors.GetString(0);
                    //resultNode.BackColor = System.Drawing.Color.Yellow;
                    resultNode.ImageIndex = 0;
                }
                else
                {
                    resultNode = tree.Nodes.Find(drSensors.GetString(1), true)[0];
                    if (resultNode == null)
                    {
                        resultNode = tree.Nodes.Add(drSensors.GetString(0),
                                                  "No parent found for " + drSensors.GetString(2));
                        resultNode.Tag = drSensors.GetString(0);
                    }
                    else
                    {
                        resultNode = resultNode.Nodes.Add(drSensors.GetString(0),
                                                        drSensors.GetString(2));
                        resultNode.Tag = drSensors.GetString(0);
                    }
                    switch (resultNode.Tag.ToString()[0])
                    {
                        case 'F':
                            {
                                resultNode.ImageIndex = 0;
                                resultNode.SelectedImageIndex=0;
                                break;
                            }
                        case 'D':
                            {
                                resultNode.ImageIndex = 1;
                                resultNode.SelectedImageIndex=1;
                                break;
                            }
                        case 'S':
                            {
                                resultNode.ImageIndex = 2;
                                resultNode.SelectedImageIndex=2;
                                break;
                            }
                    }
                    
                    //if (resultNode.Tag.ToString()[0] == 'F') resultNode.BackColor = System.Drawing.Color.Yellow;
                }
            }
            tree.Nodes[0].Expand();
            drSensors.Close();
            cn.Close();
        }
		
		/// <summary>
        /// Fills the TreeView control with the data from Piramida2000 database
        /// The data consists of hyerarchical list of all folders and devices in the database
		/// </summary>
        /// <param name="tree">Reference to the TreeView control</param>
        public void PopulateDevices(TreeView tree)
		{
            TreeNode resultNode;
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdDevices;
            SqlDataReader drDevices;
			cn.Open();
            cmdDevices = cn.CreateCommand();
			StringBuilder sql=new StringBuilder();
			sql.Append("select [key],parent,[name] from dbo.AllObjects ");
			sql.Append("where orderby='a' or orderby='b' ");
			sql.Append("order by orderby, parent,");
            sql.Append("convert(int,substring([key],2,16))");
			cmdDevices.CommandText=sql.ToString();
			drDevices=cmdDevices.ExecuteReader();
			while (drDevices.Read())
			{
				if(drDevices.GetString(1)=="F0")
				{
					resultNode=tree.Nodes.Add(drDevices.GetString(0),drDevices.GetString(2));
					resultNode.Tag=drDevices.GetString(0);
				}
				else
				{
					resultNode=tree.Nodes.Find(drDevices.GetString(1),true)[0];
					if(resultNode==null)
					{
						resultNode=tree.Nodes.Add(drDevices.GetString(0),
						                          "No parent found for " + drDevices.GetString(2));
						resultNode.Tag=drDevices.GetString(0);
					}
					else
					{
						resultNode=resultNode.Nodes.Add(drDevices.GetString(0),
						                                drDevices.GetString(2));
						resultNode.Tag=drDevices.GetString(0);
					}
				}
			}
			drDevices.Close();
			cn.Close();
		}
		
		/// <summary>
		/// Returns the list of all sensors for the given device
		/// </summary>
		/// <param name="deviceID">ID of the device</param>
		/// <returns>The list of all the device's sensors</returns>
        public List<Sensor> GetSensors(long deviceID)
		{
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdSensors;
            SqlDataReader drSensors;
            Sensor row;
			List<Sensor> result=new List<Sensor>();
            database st = new PiramidaAnalize.database();               
            try
            {
                cn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return result;
            }
            cmdSensors = cn.CreateCommand();
			StringBuilder sql=new StringBuilder();
			sql.Append("select id,code,stationid,subdeviceid,name ");
            sql.AppendFormat("from sensors where stationid={0} ", deviceID);
            sql.Append(" order by code");
            cmdSensors.CommandText = sql.ToString();
            try
            {
                drSensors = cmdSensors.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Filed to create the data adapter");
                return result;
            }
            while (drSensors.Read())
			{
				row=new Sensor();
                row.SensorID = long.Parse(drSensors["id"].ToString());
                row.SensorCode = long.Parse(drSensors["code"].ToString());
                row.DeviceID = long.Parse(drSensors["stationid"].ToString());
                if (drSensors.IsDBNull(3))
                    row.SubdeviceID = -1;
                else
                    row.SubdeviceID = long.Parse(drSensors["subdeviceid"].ToString());
                row.SensorName = drSensors["name"].ToString();
				result.Add(row);
			}			
			cn.Close();
			return result;
		}

        /// <summary>
        /// Returns the list of all devices for the given folder
        /// </summary>
        /// <param name="folderID"></param>
        /// <returns></returns>
        public List<Device> GetDevices(long folderID)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdDevices;
            SqlDataReader drDevices;
            List<Device> result=new List<Device>();
            Device newDevice;
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ID, Code, Name FROM Devices");
            sql.AppendFormat("WHERE FolderID={0}", folderID);
            
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmdDevices = cn.CreateCommand();
            cmdDevices.CommandText = sql.ToString();
            drDevices = cmdDevices.ExecuteReader();
            while (drDevices.Read())
            {
                newDevice = new Device()
                {
                    DeviceID = drDevices.GetInt32(0),
                    DeviceCode = drDevices.GetInt32(1),
                    DeviceName = drDevices.GetString(2),
                    FolderID = folderID
                };
                result.Add(newDevice);
            }
            drDevices.Close();
            cn.Close();
            return result;
        }

        /// <summary>
        /// Возвращает список всех подпапок для заданной папки.
        /// В отличие от private метода, определенного в этом же классе,
        /// здесь нет рекурсивного обхода вложенных папок, поэтому в результирующий
        /// список включаются только непосредственные дети.
        /// </summary>
        /// <param name="folderID"></param>
        /// <returns></returns>
        public List<Folder> GetImmediateFolders(long folderID)
        {
            List<Folder> result = new List<Folder>();
            Folder newFolder;
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdFolders;
            SqlDataReader drFolders;
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ID, Name FROM Folders");
            sql.AppendFormat("WHERE ParentID={0}", folderID);
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmdFolders = cn.CreateCommand();
            cmdFolders.CommandText = sql.ToString();
            drFolders = cmdFolders.ExecuteReader();
            while (drFolders.Read())
            {
                newFolder = new Folder()
                {
                    FolderID = drFolders.GetInt32(0),
                    FolderName=drFolders.GetString(1),
                    ParentFolderID=folderID
                };
                result.Add(newFolder);
            }
            drFolders.Close();
            cn.Close();
            return result;
        }
		
		/// <summary>
		/// Fills the data grid with the data from the Piramida2000 database.
        /// The data is in the form of a flat list containing all the subdevices
        /// and sensors for the given device.
		/// </summary>
		/// <param name="grid">Reference to the DataGridView control to be filled with the data</param>
		/// <param name="deviceID">The device's ID</param>
        public void FillSensors(DataGridView grid, long deviceID)
		{
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdSensors;
            if (cn.State != ConnectionState.Open)
                cn.Open();
			StringBuilder sql=new StringBuilder();
			sql.Append("select sensors.id,sensors.code,subdevices.name,sensors.name,ktr.koef ");
			sql.Append("from sensors left join subdevices ");
			sql.Append("on sensors.subdeviceid=subdevices.id ");
            sql.Append("left join ktr on sensors.id=ktr.sensorid ");
			sql.Append("where sensors.stationid=");
			sql.Append(deviceID.ToString());
            sql.Append(" order by sensors.code");
            cmdSensors = cn.CreateCommand();
			cmdSensors.CommandText=sql.ToString();			
			SqlDataAdapter daSensors=new SqlDataAdapter(cmdSensors);
			DataSet dsSensors=new DataSet();
			daSensors.Fill(dsSensors);
			grid.DataSource=dsSensors;	
			grid.DataMember=dsSensors.Tables[0].TableName;
            grid.Columns[1].HeaderText = "Код";
            grid.Columns[1].ReadOnly = true;
            grid.Columns[2].HeaderText = "Подустройство";
            grid.Columns[2].ReadOnly = true;
            grid.Columns[3].HeaderText = "Канал учёта";
            grid.Columns[3].ReadOnly = true;
            grid.Columns[4].HeaderText = "Ктр";
            grid.Columns[4].ReadOnly = false;
            grid.AutoResizeColumns();
			cn.Close();
		}

        /// <summary>
        /// Fills the data grid with the data from the Piramida2000 database.
        /// The data presents the info about the given sensor's form of the power profile curve
        /// for every day from the given date range
        /// </summary>
        /// <param name="grid">Reference to the DataGridView control to be filled with the data</param>
        /// <param name="sensorID">The sensor's ID</param>
        /// <param name="dateStart">Start of the date range</param>
        /// <param name="dateEnd">End of the date range</param>
        public void ProfileForms(DataGridView grid, long sensorID, DateTime dateStart, DateTime dateEnd)
		{
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdSensors;
            SqlDataReader drSensors;
            StringBuilder sql=new StringBuilder();
			sql.Append("SELECT Devices.ID DID, Devices.Code DCode, ");
			sql.Append("Sensors.ID SID, Sensors.Code SCode ");
			sql.Append("FROM Sensors inner join Devices on sensors.stationID=devices.ID ");
			sql.Append("WHERE Sensors.ID=");
			sql.Append(sensorID.ToString());
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmdSensors = cn.CreateCommand();
			cmdSensors.CommandText=sql.ToString();
			drSensors=cmdSensors.ExecuteReader();
			long deviceCode=-1;
			long sensorCode=-1;
			while (drSensors.Read()) {
				deviceCode=drSensors.GetInt32(1);
				sensorCode=drSensors.GetInt32(3);
			}
			drSensors.Close();
			sql.Clear();
			sql.Append("SELECT cast(left(data_date,11) as datetime) Дата, ");
			sql.Append("round(avg(value0),1) Среднее, round(stdev(value0),1) СКО, ");
			sql.Append("round((max(value0)-min(value0))/nullif(stdev(value0),0),2) Размах, ");
			sql.Append("round(stdev(value0)/nullif(avg(value0),0),2) [Форма кривой] ");
			sql.Append("FROM Data WHERE Parnumber=12 ");
			sql.Append("AND Object=");
			sql.Append(deviceCode.ToString());
			sql.Append(" AND Item=");
			sql.Append(sensorCode.ToString());
			sql.Append(" AND Data_date between '");
			sql.Append(dateStart.ToString("yyyyMMdd"));
			sql.Append(" 00:30' and '");
			sql.Append(dateEnd.AddDays(1).ToString("yyyyMMdd"));
			sql.Append("' ");			
			sql.Append("GROUP BY cast(left(data_date,11) as datetime) ORDER BY 1");
			cmdSensors.CommandText=sql.ToString();
			SqlDataAdapter daSensors=new SqlDataAdapter(cmdSensors);
			DataSet dsSensors=new DataSet();
			daSensors.Fill(dsSensors);
			grid.DataSource=dsSensors;
			grid.DataMember=dsSensors.Tables[0].TableName;
            System.Drawing.Font boldFont = new System.Drawing.Font("Courier New", 10, System.Drawing.FontStyle.Bold);
            grid.Columns[0].Width = 100;
            grid.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.Columns[0].DefaultCellStyle.Font = boldFont;
            grid.Columns[1].Width = 85;
            grid.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.Columns[2].Width = 60;
            grid.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.Columns[3].Width = 60;
            grid.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.Columns[4].Width = 120;
            grid.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.Columns[4].DefaultCellStyle.Font = boldFont;
            grid.Columns[4].DefaultCellStyle.Format = "0.000";
			cn.Close();
		}
		
		/// <summary>
		/// Returns the DataSet containing the data required to plot the 
        /// chart for daily power profile for the given sensor
		/// </summary>
		/// <param name="sensorID">The given sensor's ID</param>
		/// <param name="day1">The day for which the chart will be plotted</param>
		/// <returns>The dataset containing all the data points for the chart</returns>
        public DataSet DrawDayGraph(long sensorID, DateTime day1)
		{
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdSensors;
            DataSet result=new DataSet();
            Dictionary<string, string> sensor = SensorInfo(sensorID);
            long deviceCode = long.Parse(sensor["DeviceCode"]);
            long sensorCode = long.Parse(sensor["SensorCode"]);
            if (cn.State != ConnectionState.Open)
                cn.Open();
			StringBuilder sql=new StringBuilder();
            cmdSensors = cn.CreateCommand();
            sql.AppendFormat("select * from dbo.getprofile({0},{1},'{2}')",
                deviceCode,sensorCode,day1.ToString("yyyyMMdd"));
			cmdSensors.CommandText=sql.ToString();
			SqlDataAdapter daSensors=new SqlDataAdapter(cmdSensors);
			daSensors.Fill(result);      
			cn.Close();
			return result;
		}

        /// <summary>
        /// По ID канала (из таблицы SENSORS) возвращает информацию о канале и его устройстве
        /// (ID, Code и имя) в словаре
        /// </summary>
        /// <param name="sensorID">ID канала</param>
        /// <returns>Словарь, содержащий нужную информацию в виде, конвертированную в String'и</returns>
        public Dictionary<string, string> SensorInfo(long sensorID)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            database st = new database();
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdSensors;
            SqlDataReader drSensors;
            try
            {
                cn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Sensor info - open connection");
                return result;
            }
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT Devices.ID DeviceID, Devices.Code DeviceCode, Devices.Name DeviceName, ");
            sql.Append("Sensors.ID SensorID, Sensors.Code SensorCode, Sensors.Name SensorName ");
            sql.Append("FROM Devices INNER JOIN Sensors ON devices.ID=Sensors.StationID ");
            sql.Append("WHERE Sensors.ID=");
            sql.Append(sensorID.ToString());
            cmdSensors = cn.CreateCommand();
            cmdSensors.CommandText = sql.ToString();
            try
            {
                drSensors = cmdSensors.ExecuteReader(CommandBehavior.SingleRow);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"Sensor info - execute reader");
                return result;
            }
            if (drSensors.HasRows)
            {
                drSensors.Read();
                result["DeviceID"] = drSensors["DeviceID"].ToString();
                result["DeviceCode"] = drSensors["DeviceCode"].ToString();
                result["DeviceName"] = drSensors["DeviceName"].ToString();
                result["SensorID"] = drSensors["SensorID"].ToString();
                result["SensorCode"] = drSensors["SensorCode"].ToString();
                result["SensorName"] = drSensors["SensorName"].ToString();
            }
            drSensors.Close();
            cn.Close();
            return result;
        }

        /// <summary>
        /// Returns the sensor's code by its ID
        /// </summary>
        /// <param name="ID">Sensor's ID ([ID] field in the Sensors table)</param>
        /// <returns>Sensor's code ([Code] field in the Sensors table)</returns>
        public long GetSensorCode(long ID)
        {
            object result;
            long returnValue;
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = string.Format("SELECT Code FROM Sensors WHERE ID={0}", ID);
            result = cmd.ExecuteScalar();
            cn.Close();
            if (result != null && long.TryParse(result.ToString(), out returnValue))
                return returnValue;
            else
                return -1;
        }
        
        /// <summary>
        /// Returns the device's code by its ID
        /// </summary>
        /// <param name="ID">Device's ID ([ID] field in the Devices table)</param>
        /// <returns>Device's code ([Code] field in the Devices table)</returns>
        public long GetCode(long ID)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdDevices;
            object ret;
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmdDevices = cn.CreateCommand();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT Code FROM Devices WHERE ID=");
            sql.Append(ID.ToString());
            cmdDevices.CommandText = sql.ToString();
            ret = cmdDevices.ExecuteScalar();
            cn.Close();
            if (ret == null)
                return -1;
            else
                return long.Parse(ret.ToString());
        }

        /// <summary>
        /// Returns the device's ID by its code
        /// </summary>
        /// <param name="code">Device's code ([Code] field in the Devices table)</param>
        /// <returns>Device's ID ([ID] field in the Devices table)</returns>
        public long GetID(long code)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdDevices;
            object ret;
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmdDevices = cn.CreateCommand();
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("SELECT ID FROM Devices WHERE Code={0}", code);
            cmdDevices.CommandText = sql.ToString();
            ret = cmdDevices.ExecuteScalar();
            cn.Close();
            if (ret == null)
                return -1;
            else
                return long.Parse(ret.ToString());
        }

        /// <summary>
        /// Returns the sensor's ID by its and device's codes
        /// </summary>
        /// <param name="deviceCode">Device's code ([Code] field in the Devices table)</param>
        /// <param name="sensorCode">Sensor's's code ([Code] field in the Sensors table)</param>
        /// <returns>Device's ID ([ID] field in the Devices table)</returns>
        public long GetSensorID(long deviceCode, long sensorCode)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdDevices;
            object ret;
            cn.Open();
            cmdDevices = cn.CreateCommand();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT Sensors.ID SensorID FROM Devices INNER JOIN Sensors ON StationID=Devices.ID ");
            sql.AppendFormat("WHERE Devices.Code={0} AND Sensors.Code={1}", deviceCode, sensorCode);
            cmdDevices.CommandText = sql.ToString();
            ret = cmdDevices.ExecuteScalar();
            cn.Close();
            if (ret == null)
                return -1;
            else
                return long.Parse(ret.ToString());
        }

        /// <summary>
        /// Get the name of the Folder, Device, Subdevice or Sensor
        /// from Piramida2000 database by its ID
        /// </summary>
        /// <param name="objectType">Can be on of the following: Folder, Device, Subdevice, Sensor</param>
        /// <param name="objectID">The [ID] field value used to find the object</param>
        /// <returns></returns>
        public string GetName(string objectType, string objectID)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdSensors;
            string ret = "# Не найдено";
            object result;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT [name] FROM ");
            sql.Append(objectType);
            sql.Append("s ");
            sql.Append("WHERE ID=");
            sql.Append(objectID.ToString());
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmdSensors = cn.CreateCommand();
            cmdSensors.CommandText = sql.ToString();
            result = cmdSensors.ExecuteScalar();
            cn.Close();            
            if (result == null)
                return ret;
            else
                return result.ToString();
        }

        /// <summary>
        /// Заполняет DataGridView значениями для карты сбора данных АСКУЭ для 
        /// заданного дня и устройства. Значения карты - это процент сбора (от 0 до 100).
        /// Ещё и раскрашивает ячейки карты в зависмости от процента сбора.
        /// </summary>
        /// <param name="grid">Ссылка на элемент DataGridView, который будет отображать карту сбора</param>
        /// <param name="deviceID">ID устройства</param>
        /// <param name="day1">Собственно, день, за который строится карта</param>
        public void FillMap(DataGridView grid, string deviceID, DateTime day1)
        {
            long deviceCode = GetCode(long.Parse(deviceID));
            long sensorCode; 
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdDevices;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM dbo.GetObjectMap(");
            sql.Append(deviceID);
            sql.Append(",'");
            sql.Append(day1.ToString("yyyyMMdd"));
            sql.Append("',12)");
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmdDevices = cn.CreateCommand();
            cmdDevices.CommandText = sql.ToString();
            cmdDevices.CommandTimeout = 120;
            SqlDataAdapter daDevices = new SqlDataAdapter(cmdDevices);
            DataSet dsDevices = new DataSet();
            daDevices.Fill(dsDevices);
            grid.DataSource = dsDevices;
            grid.DataMember = dsDevices.Tables[0].TableName;
            grid.Columns[0].Width = 30;
            grid.Columns[0].Frozen = true;
            grid.Columns[0].HeaderText = "Код";
            grid.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.Columns[1].Width = 100;
            grid.Columns[1].Frozen = true;
            grid.Columns[1].HeaderText = "Канал учёта";
            grid.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.Columns[2].Visible = false;
            grid.Columns[3].Visible = false;
            for (int i = 4; i <= 51; i++)
            {
                grid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                grid.Columns[i].HeaderText = (i - 3).ToString();
                grid.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                int firstH = (i - 4) / 2;
                int firstM = ((i - 4) % 2) * 30;
                int secondH = (i - 3) / 2;
                int secondM = ((i - 3) % 2) * 30;
                grid.Columns[i].ToolTipText = string.Format("{0:00}:{1:00} - {2:00}:{3:00}", firstH, firstM, secondH, secondM);
            }
            foreach (DataGridViewRow r in grid.Rows)
            {
                sensorCode = GetSensorCode(long.Parse(r.Cells[0].Value.ToString()));
                foreach (DataGridViewCell c in r.Cells)
                    if (c.ColumnIndex > 3)
                    {
                        int v = (int)((c.Value == null) ? 0 : c.Value);
                        if (v == 100)
                            c.Style.BackColor = System.Drawing.Color.Lime;
                        else if (v > 50)
                            c.Style.BackColor = System.Drawing.Color.Orange;
                        else if (v > 0)
                            c.Style.BackColor = System.Drawing.Color.Yellow;
                        else
                            c.Style.BackColor = System.Drawing.Color.Red;
                        c.Style.ForeColor = c.Style.BackColor;
                        c.ToolTipText = GetSingleHalfhour(deviceCode, sensorCode, 
                            day1.AddMinutes((c.ColumnIndex - 3) * 30)).ToString();
                    }
            }
            cn.Close();
        }

        /// <summary>
        /// Таблица SensorSelector специально предназначена для хранения результатов выбора
        /// каналов учёта в элементах управления с возможностью множественного выбора
        /// (как деревья с чекбоксами, например).
        /// Затем эту таблицу можно использовать в многотабличных запросах
        /// </summary>
        /// <param name="tree">Ссылка на дерево с чекбоксами</param>
        public void FillTemporarySensors(TreeView tree)
        {
            
            List<long> selectedSensors = GetSelectedSensors(tree.TopNode);
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();
            SqlCommand newCommand = cn.CreateCommand();
            newCommand.CommandText = "DELETE FROM SensorSelector";
            newCommand.ExecuteNonQuery();
            if (selectedSensors.Count > 0)
            {
                foreach (long id in selectedSensors)
                {
                    newCommand.CommandText = "INSERT INTO SensorSelector (SensorID) VALUES (" + id.ToString() + ")";
                    newCommand.ExecuteNonQuery();
                }
            }
            cn.Close();
        }

        
        /// <summary>
        /// Получает из БД получасовки для заданного канала учёта
        /// </summary>
        /// <param name="dtStart">Начало периода выгрузки</param>
        /// <param name="dtEnd">Конец периода выгрузки</param>
        /// <returns>Датасет, содержащий получасовки, выгруженные из БД</returns>
        public DataSet GetHalfhours(long deviceCode, long sensorCode, DateTime dtStart, DateTime dtEnd)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdSensors;
            DataSet result = new DataSet();
            if (cn.State != ConnectionState.Open)
                cn.Open();            
            cmdSensors = cn.CreateCommand();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT Data_Date dt, value0 FROM Data ");
            sql.Append("WHERE Data_Date between '");
            sql.Append(dtStart.ToString("yyyyMMdd"));
            sql.Append(" 00:30' AND '");
            sql.Append(dtEnd.AddDays(1).ToString("yyyyMMdd"));
            sql.Append("' AND Parnumber=12 AND Object=");
            sql.Append(deviceCode);
            sql.Append(" AND Item=");
            sql.Append(sensorCode);            
            sql.Append(" ORDER BY Data_Date");
            cmdSensors.CommandText=sql.ToString();
            SqlDataAdapter daSensors=new SqlDataAdapter(cmdSensors);
            cmdSensors.CommandTimeout = 60000;
            daSensors.Fill(result);            
            cn.Close();
            return result;
        }

        /// <summary>
        /// Получает из БД получасовки за один день для заданного устройства
        /// </summary>
        /// <param name="dtDay">День, за который выгружаются данные</param>
        /// <returns>Датасет, содержащий получасовки, выгруженные из БД</returns>
        public DataSet GetHalfhoursDailyPivot(long deviceCode, DateTime dtDay)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdSensors;
            DataSet result = new DataSet();
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmdSensors = cn.CreateCommand();

            #region Compose SQL statement
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("declare @seq TABLE(i int)");
            sql.AppendLine("declare @n int");
            sql.AppendLine("set @n = 30");
            sql.AppendLine("while @n <= 1440");
            sql.AppendLine("Begin");
            sql.AppendLine("    INSERT INTO @seq(i) VALUES(@n)");
            sql.AppendLine("    set @n = @n + 30");
            sql.AppendLine("End");
            sql.AppendLine("select itemcode, itemname, ");
            sql.AppendLine("[00:30],[01:00],[01:30],[02:00],[02:30],[03:00],[03:30],[04:00],[04:30],[05:00],[05:30],[06:00],");
            sql.AppendLine("[06:30],[07:00],[07:30],[08:00],[08:30],[09:00],[09:30],[10:00],[10:30],[11:00],[11:30],[12:00],");
            sql.AppendLine("[12:30],[13:00],[13:30],[14:00],[14:30],[15:00],[15:30],[16:00],[16:30],[17:00],[17:30],[18:00],");
            sql.AppendLine("[18:30],[19:00],[19:30],[20:00],[20:30],[21:00],[21:30],[22:00],[22:30],[23:00],[23:30],[00:00]");
            sql.AppendLine("from");
            sql.AppendLine("(select item itemcode,'' itemname, value0 val,");
            sql.AppendLine("         LEFT(convert(nvarchar, data_date,108),5) halfhour");
            sql.AppendLine("   from data, @seq");
            sql.AppendFormat("   where OBJECT={0} and PARNUMBER = 12 ", deviceCode);
            sql.AppendFormat("and DATA_DATE between '{0} 00:30' and '{1}') SourceTable",
                dtDay.ToString("yyyyMMdd"),
                dtDay.AddDays(1).ToString("yyyyMMdd"));
            sql.AppendLine();
            sql.AppendLine("   PIVOT(");
            sql.AppendLine("     Max(Val)");
            sql.AppendLine("   FOR halfhour IN([00:30], [01:00], [01:30], [02:00], [02:30], [03:00], [03:30], [04:00], [04:30], [05:00], [05:30], [06:00], ");
            sql.AppendLine("                   [06:30], [07:00], [07:30], [08:00], [08:30], [09:00], [09:30], [10:00], [10:30], [11:00], [11:30], [12:00], ");
            sql.AppendLine("                   [12:30], [13:00], [13:30], [14:00], [14:30], [15:00], [15:30], [16:00], [16:30], [17:00], [17:30], [18:00], ");
            sql.AppendLine("                   [18:30], [19:00], [19:30], [20:00], [20:30], [21:00], [21:30], [22:00], [22:30], [23:00], [23:30], [00:00])");
            sql.AppendLine("       ) PivotTable");
            sql.AppendLine("ORDER BY 1");
            #endregion

            cmdSensors.CommandText = sql.ToString();
            SqlDataAdapter daSensors = new SqlDataAdapter(cmdSensors);
            cmdSensors.CommandTimeout = 60000;
            try
            {
                daSensors.Fill(result);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            result.Tables[0].TableName = "DailyData";
            List<Sensor> sensors = GetSensors(GetID(deviceCode));
            try
            {
                if (sensors.Count == result.Tables[0].Rows.Count)
                {
                    for (int i = 0; i < sensors.Count; i++)
                    {
                        result.Tables[0].Rows[i][1] = sensors[i].SensorName;
                    }
                }
                else if (result.Tables[0].Rows.Count == 0)
                {
                    for (int i = 0; i < sensors.Count; i++)
                    {
                        result.Tables[0].Rows.Add(sensors[i].SensorCode, sensors[i].SensorName);
                    }
                }
                else
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        var query = from s in sensors
                                    where s.SensorCode == (int)row[0]
                                    select s.SensorName;
                        if (query.Any())
                            row[1] = query.Single();
                        else
                            row[1] = "Неизвестный канал";                        
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "DataProvider.GetHalfhoursDailyPivot");
            }
            cn.Close();
            return result;
        }

        /// <summary>
        /// Получает из БД получасовки за один день для заданного канала учёта
        /// </summary>
        /// <param name="dtDay">День, за который выгружаются данные</param>
        /// <returns>Датасет, содержащий получасовки, выгруженные из БД</returns>
        public DataSet GetHalfhoursDaily(long deviceCode, long sensorCode, DateTime dtDay)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdSensors;
            DataSet result = new DataSet();
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmdSensors = cn.CreateCommand();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT left(convert(nvarchar,DATA_DATE, 108),5) 'time', value0 FROM Data ");
            sql.Append("WHERE Data_Date between '");
            sql.Append(dtDay.ToString("yyyyMMdd"));
            sql.Append(" 00:30' AND '");
            sql.Append(dtDay.AddDays(1).ToString("yyyyMMdd"));
            sql.Append("' AND Parnumber=12 AND Object=");
            sql.Append(deviceCode);
            sql.Append(" AND Item=");
            sql.Append(sensorCode);
            sql.Append(" ORDER BY Data_Date");
            cmdSensors.CommandText = sql.ToString();
            SqlDataAdapter daSensors = new SqlDataAdapter(cmdSensors);
            cmdSensors.CommandTimeout = 60000;
            daSensors.Fill(result);
            cn.Close();
            return result;
        }

        /// <summary>
        /// Вычисление потребления по одному каналу учета за период времени, обозначенный двумя датами.
        /// Если обе даты равны, то вычисляется потребление за один день.
        /// </summary>
        /// <param name="sensor">Код устройства и канала, скомпонованные вместе по формуле
        /// (Код устройства)*1000 + (Код канала)</param>
        /// <param name="dtStart">Дата начала периода (в таблице DATA получасовки отмечаются концом периода,
        /// поэтому в запрос добавляется это время + полчаса. Сюда нужно передавать логичное начало периода,
        /// такое как начало суток)</param>
        /// <param name="dtEnd">Дата конца периода (по той же причине в запрос передается эта дата + 1 день. 
        /// Поэтому в параметре нужно передавать конец периода ВКЛЮЧИТЕЛЬНО)</param>
        /// <returns>Значение потребления в кВт·ч за заданный период. Если по какой-то причине 
        /// запрос вернул некорректные данные, то функция вернёт -1.</returns>
        public double GetConsumption(long deviceCode, long sensorCode, DateTime dtStart, DateTime dtEnd)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdData;
            object result;
            double returnValue;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT sum(value0)/2 Consumption ");
            sql.Append("FROM Data ");
            sql.Append("WHERE parnumber=12 AND object=");
            sql.Append(deviceCode);
            sql.Append(" AND Item=");
            sql.Append(sensorCode);
            sql.Append(" AND data_date between '");
            sql.Append(dtStart.ToString("yyyyMMdd"));
            sql.Append(" 00:30' and '");
            sql.Append(dtEnd.AddDays(1).ToString("yyyyMMdd"));
            sql.Append("'");  
            if(cn.State==ConnectionState.Closed)          
                cn.Open();
            cmdData = cn.CreateCommand();
            cmdData.CommandText = sql.ToString();
            cmdData.CommandTimeout = 60000;
            result = cmdData.ExecuteScalar();
            cn.Close();
            try
            {
                returnValue = (double)result;
            }
            catch (Exception e)
            {
                returnValue = -1;
            }
            return returnValue;            
        }

        /// <summary>
        /// Вычисляет потребление по заданному каналу за период как разность конечных и
        /// начальных зафиксированных показаний с учётом коэффициента трансформации
        /// </summary>
        /// <param name="deviceCode">Код устройства (поле CODE в таблице Devices)</param>
        /// <param name="sensorCode">Код канала (поле CODE в таблице Sensors)</param>
        /// <param name="dtStart">Начало периода</param>
        /// <param name="dtEnd">Конец периода</param>
        /// <returns>Потребление в кВт·ч или -1 при ошибке</returns>
        public double GetConsumptionFixed(long deviceCode, long sensorCode, DateTime dtStart, DateTime dtEnd)
        {
            double returnValue;
            double ktr, firstVal, secondVal;
            StringBuilder sql = new StringBuilder();
            sql.Append("select koef from ktr inner join sensors on ktr.sensorid=sensors.id ");
            sql.Append("inner join devices on devices.id=sensors.stationid ");
            sql.AppendFormat("where devices.code={0} and sensors.code={1} ", deviceCode, sensorCode);
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = sql.ToString();
            try
            {
                ktr = (double)cmd.ExecuteScalar();
            }
            catch
            {
                ktr = 1;
            }
            sql.Clear();
            if (cn.State == ConnectionState.Open)
                cn.Close();
            firstVal = GetOneFixedData(deviceCode, sensorCode, dtStart);
            secondVal = GetOneFixedData(deviceCode, sensorCode, dtEnd);
            if (firstVal < 0 || secondVal < 0)
            {
                return -1;
            }
            returnValue = (secondVal - firstVal) * ktr;
            return returnValue;
        }

        /// <summary>
        /// Рекурсивная функция, которая перебирает все ветви дерева
        /// и добавляет в результирующий список только те узлы, которые 
        /// относятся к каналам связи (sensors), то есть у них тег начинается с буквы 'S', 
        /// и у которых установлен флажок.
        /// </summary>
        /// <param name="root">Корневой узел дерева</param>
        /// <returns>Список значений поля ID для выбранных каналов (sensors)</returns>
        public List<long> GetSelectedSensors(TreeNode root)
        {
            List<long> result = new List<long>();
            foreach (TreeNode n in root.Nodes)
            {
                if (n.Checked && n.Tag.ToString()[0] == 'S')
                    result.Add(long.Parse(n.Tag.ToString().Substring(1)));
                result.AddRange(GetSelectedSensors(n));
            }
            return result;
        }

        /// <summary>
        /// Рекурсивная функция, которая перебирает все ветви дерева
        /// и добавляет в результирующий список только те узлы, которые
        /// относятся к каналам связи (sensors), то есть у них имя начинается с буквы 'S',
        /// и у которых установлен флажок.
        /// </summary>
        /// <param name="root">Корневой узел дерева</param>
        /// <returns>Список имён узлов дерева, соответствующих выбранным каналам</returns>
        public List<string> GetSelectedSensorsNodes(TreeNode root)
        {
            List<string> result = new List<string>();
            foreach (TreeNode n in root.Nodes)
            {
                if (n.Checked && n.Name[0] == 'S')
                    result.Add(n.Name);
                result.AddRange(GetSelectedSensorsNodes(n));
            }
            return result;
        }

        /// <summary>
        /// Возвращает единтсвенное вещественное число - потребление по заданному каналу за день
        /// </summary>
        /// <param name="deviceCode">Код устройства</param>
        /// <param name="sensorCode">Код канала</param>
        /// <param name="theDay">День</param>
        /// <returns>Потребление в кВт·ч. Если данных нет, то возвращается 0.</returns>
        public double GetDayConsumption(long deviceCode, long sensorCode, DateTime theDay)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdData;
            double returnValue;
            object result;
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT SUM(Value0)/2 FROM DATA");
            sql.AppendFormat("WHERE Parnumber=12 AND Object={0} AND Item={1}", deviceCode, sensorCode);
            sql.AppendLine();
            sql.AppendFormat("AND Data_date BETWEEN '{0} 00:30' AND '{1}'", 
                theDay.ToString("yyyyMMdd"), theDay.AddDays(1).ToString("yyyyMMdd"));
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmdData = cn.CreateCommand();
            cmdData.CommandText = sql.ToString();
            result = cmdData.ExecuteScalar();            
            cn.Close();
            try
            {
                returnValue = (double)result;
            }
            catch (Exception e)
            {
                returnValue = 0;
            }
            return returnValue;
        }

        /// <summary>
        /// Возвращает коэффициент трансформации для заданного канала учета
        /// </summary>
        /// <param name="sensorID">ID канала учета</param>
        /// <returns>Коэффициент трансформации (расчетный коэффициент)</returns>
        public double GetKTR(long sensorID)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdData;
            object result;            
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmdData = cn.CreateCommand();
            cmdData.CommandText = string.Format("SELECT Koef FROM KTR WHERE SensorID={0}", sensorID);
            result = cmdData.ExecuteScalar();                        
            cn.Close();
            if (result == null)
                return 1;
            else
                return double.Parse(result.ToString());
        }

        /// <summary>
        /// Возвращает единственную получасовку
        /// </summary>
        /// <param name="deviceCode">Код устройства (object в таблице DATA)</param>
        /// <param name="sensorCode">Код канала (item в таблице DATA)</param>
        /// <param name="halfhourPoint">Время получасовки</param>
        /// <returns>Значение получасовки</returns>
        public double GetSingleHalfhour(long deviceCode, long sensorCode, DateTime halfhourPoint)
        {
            double result = -1;
            StringBuilder sql = new StringBuilder();
            SqlConnection cn = new SqlConnection(connectionString);
            SqlDataReader drData;
            sql.Append("SELECT value0 FROM DATA ");
            sql.Append("WHERE Parnumber=12 AND ");
            sql.AppendFormat("Data_date='{0}' ", halfhourPoint.ToString("yyyyMMdd HH:mm"));
            sql.AppendFormat("AND Object={0} and Item={1} ", deviceCode, sensorCode);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = sql.ToString();
            drData = cmd.ExecuteReader(CommandBehavior.SingleRow);
            if (drData.Read())
                result = drData.GetDouble(0);
            drData.Close();
            cn.Close();
            return result;
        }

        /// <summary>
        /// Возвращает все зафиксированные на начало суток показания
        /// (параметр 101) для заданного канала за период
        /// </summary>
        /// <param name="deviceCode">Код устройства</param>
        /// <param name="sensorCode">Код канала</param>
        /// <param name="dtStart">Дата начала периода</param>
        /// <param name="dtEnd">Дата окончания периода</param>
        /// <returns>Датасет с показаниями и датами</returns>
        public DataSet GetFixedData(long deviceCode, long sensorCode, DateTime dtStart, DateTime dtEnd)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdData;
            DataSet result = new DataSet();
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select data_date, VALUE0 from data");
            sql.AppendLine("where PARNUMBER=101");
            sql.AppendFormat("and OBJECT={0} and ITEM={1}", deviceCode, sensorCode);
            sql.AppendLine();
            sql.AppendFormat("and DATA_DATE between '{0}' and '{1}'", 
                dtStart.ToString("yyyyMMdd"), dtEnd.ToString("yyyyMMdd"));
            sql.AppendLine();
            sql.AppendLine("order by DATA_DATE");
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmdData = cn.CreateCommand();
            cmdData.CommandText = sql.ToString();
            SqlDataAdapter daData = new SqlDataAdapter(cmdData);
            daData.Fill(result);
            cn.Close();
            return result;
        }

        /// <summary>
        /// Возвращает единственное значение - зафиксированные показания
        /// для заданного канала учёта на заданный момент времени (начало заданных суток)
        /// </summary>
        /// <param name="deviceCode">Код устройства</param>
        /// <param name="sensorCode">Код канала</param>
        /// <param name="theDay">Дата</param>
        /// <returns>Показания в виде вещественного числа, если данных нет, то возвращает -1, нужно делать проверку.</returns>
        public double GetOneFixedData(long deviceCode, long sensorCode, DateTime theDay)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdData;
            double returnValue;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT Value0 FROM DATA WHERE Parnumber=101 ");
            sql.AppendFormat("AND Object={0} AND Item={1} ", deviceCode, sensorCode);
            sql.AppendFormat("AND Data_date='{0}' ", theDay.ToString("yyyyMMdd"));
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmdData = cn.CreateCommand();
            cmdData.CommandText = sql.ToString();
            object result = cmdData.ExecuteScalar();
            cn.Close();
            try
            {
                returnValue = (double)result;
            }
            catch (Exception e)
            {
                returnValue = -1;
            }
            return returnValue;
        }

        /// <summary>
        /// Возвращает единственное значение - последние имеющиеся в БД
        /// зафиксированные показания вместе с датой
        /// </summary>
        /// <param name="deviceCode">Код устройства</param>
        /// <param name="sensorCode">Код канала учета</param>
        /// <returns>Структура с полями для собственно показаний и их даты</returns>
        public DataPoint GetLastFixedData(long deviceCode, long sensorCode)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdData;
            DataPoint returnValue;
            SqlDataReader drData;
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT Top 1 Data_date, Value0 FROM DATA WHERE Parnumber=101");
            sql.AppendFormat("AND Object={0} AND Item={1}", deviceCode, sensorCode);
            sql.AppendLine();
            sql.AppendLine("ORDER BY Data_date desc");
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmdData = cn.CreateCommand();
            cmdData.CommandText = sql.ToString();
            drData = cmdData.ExecuteReader(CommandBehavior.SingleRow);
            if (drData.Read())
            {
                returnValue.TimeStamp = drData.GetDateTime(0);
                returnValue.DataEntry = drData.GetDouble(1);
            }
            else
            {
                // There was no fixed data for this channel
                returnValue.TimeStamp = DateTime.MinValue;
                returnValue.DataEntry = -1;
            }
            cn.Close();            
            return returnValue;
        }

        /// <summary>
        /// Возвращает единственное значение - последние имеющиеся в БД
        /// зафиксированные показания вместе с датой, ранее указанной даты
        /// </summary>
        /// <param name="deviceCode">Код устройства</param>
        /// <param name="sensorCode">Код канала учета</param>
        /// <param name="priorToThis">Искать последние показания раньше этого дня</param>
        /// <returns>Структура с полями для собственно показаний и их даты</returns>
        public DataPoint GetPriorFixedData(long deviceCode, long sensorCode, DateTime priorToThis)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdData;
            DataPoint returnValue;
            SqlDataReader drData;
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT Top 1 Data_date, Value0 FROM DATA WHERE Parnumber=101");
            sql.AppendFormat("AND Object={0} AND Item={1} ", deviceCode, sensorCode);
            sql.AppendFormat("AND Data_Date<'{0}' ",priorToThis.ToString("yyyyMMdd"));
            sql.AppendLine("ORDER BY Data_date desc");
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmdData = cn.CreateCommand();
            cmdData.CommandText = sql.ToString();
            drData = cmdData.ExecuteReader(CommandBehavior.SingleRow);
            if (drData.Read())
            {
                returnValue.TimeStamp = drData.GetDateTime(0);
                returnValue.DataEntry = drData.GetDouble(1);
            }
            else
            {
                // There was no fixed data for this channel
                returnValue.TimeStamp = DateTime.MinValue;
                returnValue.DataEntry = -1;
            }
            cn.Close();
            return returnValue;
        }

        /// <summary>
        /// Tries to connect to the database with the default connection string.
        /// Returns true if succeeds, false otherwise
        /// </summary>
        /// <returns></returns>
        public bool TestConnection()
        {
            bool result = true;
            SqlConnection cn = new SqlConnection(connectionString);
            try
            {
                cn.Open();
            }
            catch (SqlException ex)
            {
                result = false;
            }
            catch (Exception ex)
            {
                result = false;
            }
            if (cn.State == ConnectionState.Open)
                cn.Close();
            return result;
        }

        /// <summary>
        /// Tries to connect to the database with the provided connection string
        /// </summary>
        /// <param name="wcs">Connection string with a login that may execute certain stored procedures</param>
        /// <returns>true if successful</returns>
        public bool TestWriter(string wcs)
        {
            bool result = true;
            SqlConnection cn = new SqlConnection(wcs);
            
            try
            {
                cn.Open();
                
            }
            catch
            {
                result = false;
            }
            if (cn.State == ConnectionState.Open)
                cn.Close();
            return result;
        }

        #region Наборы каналов

        /// <summary>
        /// Saves a set of sensor IDs in SensorSets table in the database
        /// </summary>
        /// <param name="title">The set's unique name</param>
        /// <param name="sensorIDs">A string containing sensor IDs separated by semicolons</param>
        /// <returns>true if the operation was successful</returns>
        public bool SaveSensorsSet(string title, string[] sensorIDs)
        {
            object dbResult;
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string sql = "SELECT count(*) FROM SensorSets WHERE Title='" + title + "'";
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = sql;
                try
                {
                    dbResult = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при проверке имени набора" + Environment.NewLine + ex.Message,
                        "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (dbResult == null || Convert.IsDBNull(dbResult))
                {
                    MessageBox.Show("Запрос " + sql + Environment.NewLine + "вернул пустой набор строк",
                        "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if ((int)dbResult > 0)
                {
                    MessageBox.Show("Набор с именем " + title + " уже существует", "Неправильное имя",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                sql = "INSERT INTO SensorSets (Title,SensorIDs) VALUES ('" + title + "','" +
                    string.Join(";", sensorIDs) + "')";
                cmd.CommandText = sql;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка записи набора в БД:" + Environment.NewLine + ex.Message,
                        "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Reads an array of sensor IDs from a database table
        /// </summary>
        /// <param name="title">The set's unique name</param>
        /// <returns>An array of IDs in the same format which is used to identify the channels in the object tree</returns>
        public string[] ReadSensorsSet(string title)
        {
            string[] result;
            object dbResult;
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string sql = "SELECT SensorIDs FROM SensorSets WHERE Title='" + title + "'";
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = sql;
                try
                {
                    dbResult = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка выполнения запроса:" + Environment.NewLine + sql + Environment.NewLine + ex.Message,
                        "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                if (dbResult == null || Convert.IsDBNull(dbResult))
                {
                    MessageBox.Show("Набор " + title + Environment.NewLine + "не существует в базе данных",
                        "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                try
                {
                    result = dbResult.ToString().Split(';');
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка распознавания списка каналов:" + Environment.NewLine + dbResult.ToString() + 
                        Environment.NewLine + ex.Message,
                        "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            return result;
        }

        /// <summary>
        /// Deletes a set of sensor IDs by its title
        /// </summary>
        /// <param name="title">The set's unique name</param>
        /// <returns>true if the operation was successful</returns>
        public bool DeleteSensorsSet(string title)
        {
            object dbResult;
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string sql = "SELECT count(*) FROM SensorSets WHERE Title='" + title + "'";
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = sql;
                try
                {
                    dbResult = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при проверке имени набора" + Environment.NewLine + ex.Message,
                        "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (dbResult == null || Convert.IsDBNull(dbResult))
                {
                    MessageBox.Show("Запрос " + sql + Environment.NewLine + "вернул пустой набор строк",
                        "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if ((int)dbResult == 0)
                {
                    MessageBox.Show("Набор с именем " + title + " не существует в базе данных", "Невозможно удалить",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                sql = "DELETE FROM SensorSets WHERE Title='" + title + "'";
                cmd.CommandText = sql;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка записи набора в БД:" + Environment.NewLine + ex.Message,
                        "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Gets the full list of sensor sets' names from the database
        /// </summary>
        /// <returns>The list of sensor sets' names as an array of strings</returns>
        public string[] GetSensorSetsList()
        {
            List<string> result;
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string sql = "SELECT Title FROM SensorSets";
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = sql;
                SqlDataReader dr;
                try
                {
                    dr = cmd.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка выполнения запроса:" + Environment.NewLine + sql + Environment.NewLine + ex.Message,
                        "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                result = new List<string>();
                while (dr.Read())
                    result.Add(dr[0].ToString());
            }
            return result.ToArray();
        }

        #endregion

        #region Запись данных в базу

        public bool WriteKtr(string writeConnectionString, int sensorID, double newKtr)
        {
            bool result = true;
            object existing;
            using (SqlConnection cn = new SqlConnection(writeConnectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "SELECT Count(*) FROM Ktr WHERE SensorID=" + sensorID;
                try
                {
                    existing = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Не удалось получить информацию о Ктр", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                StringBuilder sql = new StringBuilder(100);
                if ((int)existing == 0)
                {
                    sql.AppendFormat("INSERT INTO Ktr (SensorID,Koef) Values ({0},{1})", sensorID, newKtr.ToString().Replace(',', '.'));
                }
                else
                {
                    sql.AppendFormat("UPDATE Ktr SET Koef={0} WHERE SensorID={1}", newKtr.ToString().Replace(',', '.'), sensorID);
                }
                cmd.CommandText = sql.ToString();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка функции записи Ктр в БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return result;
        }

        /// <summary>
        /// Записывает в БД Piramida2000 одно значение путём выполнения хранимой процедуры
        /// SP_ADD_DATA
        /// </summary>
        /// <param name="writeConnectionString">Строка подключения строится вне этого метода</param>
        /// <param name="parnumber">12 - получасовки, 101 - зафиксированные показания</param>
        /// <param name="deviceCode">Код устройства (поле Object в таблице DATA)</param>
        /// <param name="sensorCode">Код канала (поле Item в таблице DATA)</param>
        /// <param name="datePoint">Дата и время точки</param>
        /// <param name="val">Собственно значение</param>
        /// <returns>TRUE если всё прошло как надо</returns>
        public bool WriteOneData(string writeConnectionString, int parnumber, long deviceCode, long sensorCode,
            DateTime datePoint, double val)
        {
            bool result = true;
            SqlConnection cn = new SqlConnection(writeConnectionString);
            SqlCommand cmd;
            try
            {
                cn.Open();
                cmd = new SqlCommand("dbo.AddOneData", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@parnumber_", parnumber);
                cmd.Parameters.AddWithValue("@object_", deviceCode);
                cmd.Parameters.AddWithValue("@item_", sensorCode);
                cmd.Parameters.AddWithValue("@data_date_", datePoint);
                cmd.Parameters.AddWithValue("@value_", val);
                int rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка функции записи в БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            finally
            {
                cn.Close();
            }
            return result;
        }

        /// <summary>
        /// Удаляет из БД Piramida2000 одно значение (одну строку из таблицы DATA),
        /// используя хранимую процедуру DeleteOneData (не является стандартной для Пирамиды)
        /// </summary>
        /// <param name="writeConnectionString">Строка подключения строится вне этого метода</param>
        /// <param name="parnumber">12 - получасовки, 101 - зафиксированные показания</param>
        /// <param name="deviceCode">Код устройства (поле Object в таблице DATA)</param>
        /// <param name="sensorCode">Код канала (поле Item в таблице DATA)</param>
        /// <param name="datePoint">Дата и время точки</param>
        /// <returns>TRUE если всё прошло как надо</returns>
        public bool ClearOneData(string writeConnectionString, int parnumber, long deviceCode, long sensorCode,
            DateTime datePoint)
        {
            #region DISCLAIMER! DeleteOneData stored procedure and Data_log table required in the db Piramida2000
            // ВНИМАНИЕ! Для работы функции нужны:
            // а) хранимая процедура DeleteOneData
            // б) таблица Data_log
            // Они не входят в стандартный набор объектов БД Piramida2000
            // В проекте приложены скрипты их создания
            #endregion
            bool result = true;
            SqlConnection cn = new SqlConnection(writeConnectionString);
            SqlCommand cmd;
            SqlTransaction trans;
            try
            {
                cn.Open();
                cmd = new SqlCommand("dbo.DeleteOneData", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@parnumber", parnumber);
                cmd.Parameters.AddWithValue("@object", deviceCode);
                cmd.Parameters.AddWithValue("@item", sensorCode);
                cmd.Parameters.AddWithValue("@data_date", datePoint);
                trans = cn.BeginTransaction();
                cmd.Transaction = trans;
                int rows = cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка функции удаления из БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            if (cn.State == ConnectionState.Open)
                cn.Close();
            return result;
        }
        #endregion

        #region Подсчеты количества значений и процентов сбора

        /// <summary>
        /// Возвращает ожидаемое количество значений получасовок для заданного канала
        /// за заданный интервал времени, если бы сбор составил 100%
        /// </summary>
        /// <param name="sensorID">ID канала учета</param>
        /// <param name="interval">тип интервала: day, week, month или year</param>
        /// <param name="daysCount">для интервалов month и year желательно указать количество дней,
        /// соответственно, в заданном месяце и году, иначе для расчета будет использоваться значение
        /// 30 для месяца и 365 для года</param>
        /// <param name="parameter">12 - получасовки; 101 - зафиксированные показания</param>
        /// <returns>Ожидаемое количество значений</returns>
        public long ExpectedInSensor(long sensorID, string interval, int daysCount=0, int parameter=12)
        {
            long result = 0;
            switch (interval)
            {
                case "halfhour":
                    {
                        result = (parameter == 12) ? result = 1 : result = 0;
                        break;
                    }
                case "day":
                    {
                        result = (parameter == 12) ? result = 48 : result = 1;
                        break;
                    }
                case "week":
                    {
                        result = (parameter == 12) ? result = 336 : result = 7; //336 = 7*48
                        break;
                    }
                case "month":
                    {
                        if (parameter == 12)
                            result = (daysCount > 0 && daysCount <= 31) ? 48 * daysCount : 1440; //1440 = 30*48
                        else
                            result = (daysCount > 0 && daysCount <= 31) ? daysCount : 30;
                        break;
                    }
                case "year":
                    {
                        if (parameter == 12)
                            result = (daysCount > 0 && daysCount <= 366) ? 48 * daysCount : 17520; //17520 = 365*48
                        else
                            result = (daysCount > 0 && daysCount <= 366) ? daysCount : 365;
                        break;
                    }
            }
            return result;
        }

        /// <summary>
        /// Возвращает ожидаемое количество значений получасовок для заданного устройства
        /// за заданный интервал времени, если бы сбор составил 100%
        /// </summary>
        /// <param name="deviceID">ID устройства</param>
        /// <param name="interval">тип интервала: day, week, month или year</param>
        /// <param name="daysCount">для интервалов month и year желательно указать количество дней,
        /// соответственно, в заданном месяце и году, иначе для расчета будет использоваться значение
        /// 30 для месяца и 365 для года</param>
        /// <param name="parameter">12 - получасовки; 101 - зафиксированные показания</param>
        /// <returns>Ожидаемое количество значений</returns>
        public long ExpectedInDevice(long deviceID, string interval, int daysCount = 0, int parameter = 12)
        {
            long result = 0;
            List<Sensor> sensors = GetSensors(deviceID);
            foreach (Sensor s in sensors)
            {
                result += ExpectedInSensor(s.SensorID, interval, daysCount, parameter);
            }
            return result;
        }

        /// <summary>
        /// Возвращает ожидаемое количество значений получасовок для заданной папки
        /// и всех её вложенных папок за заданный интервал времени, если бы сбор составил 100%
        /// </summary>
        /// <param name="deviceID">ID папки</param>
        /// <param name="interval">тип интервала: day, week, month или year</param>
        /// <param name="daysCount">для интервалов month и year желательно указать количество дней,
        /// соответственно, в заданном месяце и году, иначе для расчета будет использоваться значение
        /// 30 для месяца и 365 для года</param>
        /// <param name="parameter">12 - получасовки; 101 - зафиксированные показания</param>
        /// <returns>Ожидаемое количество значений</returns>
        public long ExpectedInFolder(long folderID, string interval, int daysCount = 0, int parameter = 12)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdDevices;
            SqlDataReader drDevices;
            StringBuilder sql = new StringBuilder();
            long result = 0;
            List<long> children = GetChildFolders(folderID);
            children.Add(folderID);
            sql.Append("SELECT ID FROM Devices WHERE FolderID IN (");
            foreach (long currentFolder in children)
            {
                sql.Append(currentFolder.ToString());
                sql.Append(",");
            }
            if (sql[sql.Length - 1] == ',')
                sql.Remove(sql.Length - 1, 1);
            sql.Append(")");
            cn.Open();
            cmdDevices = cn.CreateCommand();
            cmdDevices.CommandText = sql.ToString();
            drDevices = cmdDevices.ExecuteReader();
            while (drDevices.Read())
            {
                result += ExpectedInDevice(drDevices.GetInt32(0), interval, daysCount, parameter);
            }
            drDevices.Close();
            cn.Close();
            return result;
        }

        /// <summary>
        /// Возвращает фактическое количество значений заданного параметра (12 или 101) по
        /// заданному каналу учёта за заданный интервал времени
        /// </summary>
        /// <param name="sensorID">ID канала учета</param>
        /// <param name="interval">тип интервала: day, week, month или year</param>
        /// <param name="baseDate">Дата первого дня, начинающего заданный интервал</param>
        /// <param name="parNumber">Номер параметра: 12 (получасовки) или 101 (зафиксированные показания). 
        /// По умолчанию = 12</param>
        /// <returns></returns>
        public long FactInSensor(long sensorID, string interval, DateTime baseDate, int parNumber=12)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdData;
            object result = 0;
            Dictionary<string, string> sensorInfo = SensorInfo(sensorID);
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("SELECT Count(*) FROM DATA WHERE Parnumber={0} ", parNumber);
            sql.AppendFormat("AND Object={0} AND Item={1} ", sensorInfo["DeviceCode"], sensorInfo["SensorCode"]);
            switch (interval)
            {
                case "halfhour":
                    {
                        sql.AppendFormat("AND Data_date='{0}'", baseDate.AddMinutes(30).ToString("yyyyMMdd HH:mm"));
                        break;
                    }
                case "day":
                    {
                        if (parNumber == 12)
                            sql.AppendFormat("AND Data_date between '{0}' AND '{1}'",
                                             baseDate.AddMinutes(30).ToString("yyyyMMdd HH:mm"),
                                             baseDate.AddDays(1).ToString("yyyyMMdd"));
                        else
                            sql.AppendFormat("AND Data_date='{0}'", baseDate.ToString("yyyyMMdd"));
                        break;
                    }
                case "week":
                    {
                        baseDate = baseDate.FirstDayOfWeek();
                        if (parNumber == 12)
                            baseDate = baseDate.AddMinutes(30);
                        sql.AppendFormat("AND Data_date between '{0}' AND '{1}'",
                            baseDate.ToString("yyyyMMdd HH:mm"),
                            baseDate.AddDays((parNumber == 12) ? 7 : 6).ToString("yyyyMMdd"));
                        break;
                    }
                case "month":
                    {
                        baseDate = baseDate.FirstDayOfMonth();
                        if (parNumber == 12)
                        {
                            baseDate = baseDate.AddMinutes(30);
                            sql.AppendFormat("AND Data_date between '{0}' AND '{1}'",
                                baseDate.ToString("yyyyMMdd HH:mm"),
                                baseDate.AddMonths(1).ToString("yyyyMMdd"));
                        }
                        else
                            sql.AppendFormat("AND Data_date between '{0}' and '{1}'",
                                baseDate.ToString("yyyyMMdd"),
                                baseDate.AddMonths(1).AddDays(-1).ToString("yyMMdd"));
                        break;
                    }
                case "year":
                    {
                        baseDate = baseDate.FirstDayOfYear();
                        if (parNumber == 12)
                        {
                            baseDate = baseDate.AddMinutes(30);
                            sql.AppendFormat("AND Data_date between '{0}' AND '{1}'",
                                baseDate.ToString("yyyyMMdd HH:mm"),
                                baseDate.AddYears(1).ToString("yyyyMMdd"));
                        }
                        else
                            sql.AppendFormat("AND Data_date between '{0}' and '{1}'",
                                baseDate.ToString("yyyyMMdd"),
                                baseDate.AddYears(1).AddDays(-1).ToString("yyyyMMdd"));
                        break;
                    }
            }
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmdData = cn.CreateCommand();
            cmdData.CommandText = sql.ToString();
            cmdData.CommandTimeout = 600;
            result = cmdData.ExecuteScalar();
            cn.Close();
            if (result == null)
                return 0;
            else
                return long.Parse(result.ToString());
        }

        /// <summary>
        /// Возвращает фактическое количество значений заданного параметра (12 или 101) по
        /// всем каналам заданного устройства за заданный интервал времени
        /// </summary>
        /// <param name="deviceID">ID устройства</param>
        /// <param name="interval">тип интервала: day, week, month или year</param>
        /// <param name="baseDate">Дата первого дня, начинающего заданный интервал</param>
        /// <param name="parNumber">Номер параметра: 12 (получасовки) или 101 (зафиксированные показания). 
        /// По умолчанию = 12</param>
        /// <returns></returns>
        public long FactInDevice(long deviceID, string interval, DateTime baseDate, int parNumber=12)
        {
            //long result = 0;
            //List<Sensor> sensors = GetSensors(deviceID);
            //foreach (Sensor s in sensors)
            //{
            //    result += FactInSensor(s.SensorID, interval, baseDate, parNumber);
            //}
            //return result;
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdData;
            object result = 0;
            long deviceCode = GetCode(deviceID);
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("SELECT Count(*) FROM DATA WHERE Parnumber={0} ", parNumber);
            sql.AppendFormat("AND Object={0} ", deviceCode);
            switch (interval)
            {
                case "halfhour":
                    {
                        sql.AppendFormat("AND Data_date='{0}'", baseDate.ToString("yyyyMMdd HH:mm"));
                        break;
                    }
                case "day":
                    {
                        if (parNumber == 12)
                            sql.AppendFormat("AND Data_date between '{0}' AND '{1}'",
                                             baseDate.AddMinutes(30).ToString("yyyyMMdd HH:mm"),
                                             baseDate.AddDays(1).ToString("yyyyMMdd"));
                        else
                            sql.AppendFormat("AND Data_date='{0}'", baseDate.ToString("yyyyMMdd"));
                        break;
                    }
                case "week":
                    {
                        baseDate = baseDate.FirstDayOfWeek();
                        if (parNumber == 12)
                            baseDate = baseDate.AddMinutes(30);
                        sql.AppendFormat("AND Data_date between '{0}' AND '{1}'",
                            baseDate.ToString("yyyyMMdd HH:mm"),
                            baseDate.AddDays((parNumber == 12) ? 7 : 6).ToString("yyyyMMdd"));
                        break;
                    }
                case "month":
                    {
                        baseDate = baseDate.FirstDayOfMonth();
                        if (parNumber == 12)
                        {
                            baseDate = baseDate.AddMinutes(30);
                            sql.AppendFormat("AND Data_date between '{0}' AND '{1}'",
                                baseDate.ToString("yyyyMMdd HH:mm"),
                                baseDate.AddMonths(1).ToString("yyyyMMdd"));
                        }
                        else
                            sql.AppendFormat("AND Data_date between '{0}' and '{1}'",
                                baseDate.ToString("yyyyMMdd"),
                                baseDate.AddMonths(1).AddDays(-1).ToString("yyMMdd"));
                        break;
                    }
                case "year":
                    {
                        baseDate = baseDate.FirstDayOfYear();
                        if (parNumber == 12)
                        {
                            baseDate = baseDate.AddMinutes(30);
                            sql.AppendFormat("AND Data_date between '{0}' AND '{1}'",
                                baseDate.ToString("yyyyMMdd HH:mm"),
                                baseDate.AddYears(1).ToString("yyyyMMdd"));
                        }
                        else
                            sql.AppendFormat("AND Data_date between '{0}' and '{1}'",
                                baseDate.ToString("yyyyMMdd"),
                                baseDate.AddYears(1).AddDays(-1).ToString("yyyyMMdd"));
                        break;
                    }
            }
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmdData = cn.CreateCommand();
            cmdData.CommandText = sql.ToString();
            cmdData.CommandTimeout = 600;
            result = cmdData.ExecuteScalar();
            cn.Close();
            if (result == null)
                return 0;
            else
                return long.Parse(result.ToString());

        }

        /// <summary>
        /// Возвращает фактическое количество значений заданного параметра (12 или 101) по всем каналам 
        /// всех устройств заданной папки за заданный интервал времени
        /// </summary>
        /// <param name="folderID">ID папки</param>
        /// <param name="interval">тип интервала: day, week, month или year</param>
        /// <param name="baseDate">Дата первого дня, начинающего заданный интервал</param>
        /// <param name="parNumber">Номер параметра: 12 (получасовки) или 101 (зафиксированные показания). 
        /// По умолчанию = 12</param>
        /// <returns></returns>
        public long FactInFolder(long folderID, string interval, DateTime baseDate, int parNumber = 12)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdDevices;
            SqlDataReader drDevices;
            long result = 0;
            List<long> children = GetChildFolders(folderID);
            children.Add(folderID);
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmdDevices = cn.CreateCommand();
            foreach (long currentFolder in children)
            {
                string sql = "SELECT ID FROM Devices WHERE FolderID=" + currentFolder.ToString();
                cmdDevices.CommandText = sql;
                drDevices = cmdDevices.ExecuteReader();
                while (drDevices.Read())
                {
                    result += FactInDevice(drDevices.GetInt32(0), interval, baseDate, parNumber);
                }
                drDevices.Close();
            }
            cn.Close();
            return result;
        }

        /// <summary>
        /// Возвращает процент сбора по заданному каналу или устройству за заданный интервал времени
        /// </summary>
        /// <param name="dateStart">Начало периода</param>
        /// <param name="dateEnd">Конец периода</param>
        /// <param name="parameter">12 - получасовки, 101 - зафиксированные показания</param>
        /// <param name="entireDevice">Если true - ведётся расчет для всего устройства, если false -
        /// то для одного канала</param>
        /// <param name="ObjectCode">Код устройства (поле Object в таблице Data)</param>
        /// <param name="ItemCode">Код канала (поле Item в таблице Data)</param>
        /// /// <returns>Процент сбора или -1 при ошибке</returns>
        public int GetPercent(DateTime dateStart, DateTime dateEnd,
             int parameter, bool entireDevice, long ObjectCode, long ItemCode = 0)
        {
            object result;
            string functionName = (entireDevice) ? "dbo.GetPercentDevice" : "dbo.GetPercent";
            functionName = functionName + parameter.ToString();
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            string sql = string.Format("select {0}({1}{2},'{3}','{4}')",
                functionName, ObjectCode, (entireDevice) ? "" : "," + ItemCode.ToString(),
                dateStart.ToString("yyyyMMdd HH:mm"), dateEnd.ToString("yyyyMMdd HH:mm"));
            cmd.CommandText = sql;
            result = cmd.ExecuteScalar();
            cn.Close();
            if (result == null)
                return -1;
            else
                return (int)result;
        }

        /// <summary>
        /// Возвращает процент сбора по заданной папке за заданный интервал времени
        /// </summary>
        /// <param name="dateStart">Начало периода</param>
        /// <param name="dateEnd">Конец периода</param>
        /// <param name="parameter">12 - получасовки, 101 - зафиксированные показания</param>
        /// <param name="folderID">ID папки (поле FolderID в таблице Devices)</param>
        /// <returns>Процент сбора или -1 при ошибке</returns>
        public int GetFolderPercent(DateTime dateStart, DateTime dateEnd, int parameter, long folderID)
        {
            object result;
            string functionName = "dbo.GetPercentFolder" + parameter.ToString();
            string sql = string.Format("select {0}({1},'{2}','{3}')",
                functionName, folderID, dateStart.ToString("yyyyMMdd HH:mm"), dateEnd.ToString("yyyyMMdd HH:mm"));
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = sql;
            try
            {
                result = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                result = -1;
            }
            cn.Close();
            if (result == null)
                return -1;
            else
                return (int)result;
        }

        #endregion

        #region Балансы

        /// <summary>
        /// Возвращает список существующих в базе балансов, в которых участвует
        /// хоть один канал заданного устройства
        /// </summary>
        /// <param name="deviceID">ID устройства</param>
        /// <returns>Dataset со списком балансов</returns>
        public DataSet GetBalanceList(long deviceID)
        {
            DataSet result = new DataSet();
            SqlConnection cn = new SqlConnection(connectionString);
            StringBuilder sql = new StringBuilder();
            sql.Append("select ID Номер, Title 'Название баланса', '...' Редактировать ");
            sql.Append("from Balance_main ");
            sql.Append("where ID in ");
            sql.Append("(select distinct Balance.No from Balance ");
            sql.Append("where OBJECT = @device)");
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@device", GetCode(deviceID));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(result);
            cn.Close();
            return result;
        }

        /// <summary>
        /// Возвращает текущий список отмеченных балансов или всю таблицу Balance_main
        /// </summary>
        /// <param name="onlyChecked">Если true, то выбираются только те, балансы, у которых установлен флажок</param>
        /// <returns>Датасет с одной таблицей Balance_main</returns>
        public DataSet GetAllBalances(bool onlyChecked)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from balance_main ");
            if (onlyChecked)
                sql.Append("where [check]=1 ");
            sql.Append("order by title");
            DataSet result = new DataSet();
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = sql.ToString();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(result);
            if (cn.State == ConnectionState.Open)
                cn.Close();
            return result;
        }

        /// <summary>
        /// Возвращает список составляющих баланса в виде Dataset
        /// </summary>
        /// <param name="balanceNo">Номер баланса (он же foreign key для связи с Balance_main</param>
        /// <returns>Список каналов, участвующих в балансе</returns>
        public DataSet GetBalanceDetails(long balanceNo)
        {
            DataSet result = new DataSet();
            SqlConnection cn = new SqlConnection(connectionString);
            StringBuilder sql = new StringBuilder();
            sql.Append("select[SIGN] Знак, DEVICES.NAME Объект, SENSORS.NAME Канал, Parnumber Параметр, ");
            sql.Append("Devices.Code ObjCode, Sensors.Code SensorCode ");
            sql.Append("from Balance inner join DEVICES on Balance.Object = DEVICES.CODE ");
            sql.Append("inner join SENSORS on (Balance.Item = SENSORS.CODE and SENSORS.STATIONID = DEVICES.ID)  ");
            sql.Append("where Balance.No = @balancenumber");
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@balancenumber", balanceNo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(result);
            cn.Close();
            return result;
        }

        /// <summary>
        /// Просто название баланса, т.е. поле Title из таблицы Balance_main
        /// </summary>
        /// <param name="balanceNo">Номер баланса (он же поле ID в таблице)</param>
        /// <returns>Собственно, название баланса</returns>
        public string GetBalanceName(long balanceNo)
        {
            string result;
            StringBuilder sql = new StringBuilder();
            sql.Append("select title from balance_main ");
            sql.AppendFormat("where id={0}", balanceNo);
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = sql.ToString();
            try
            {
                result = cmd.ExecuteScalar().ToString();
            }
            catch
            {
                throw new Exception("Баланс не найден");
            }
            if (cn.State == ConnectionState.Open)
                cn.Close();
            return result;
        }

        /// <summary>
        /// Переключает значение флажка Check в таблице Balance,
        /// для чего использует хранимую процедуру
        /// </summary>
        /// <param name="balanceNo">Значение поля ID в таблице</param>
        /// <returns>Новое состояние флажка</returns>
        public bool ToggleBalanceSelection(long balanceNo)
        {
            #region DISCLAIMER! DeleteOneData stored procedure and Data_log table required in the db Piramida2000
            // ВНИМАНИЕ! Для работы функции нужны:
            // а) хранимая процедура ToggleBalanceSelected
            // б) таблица Balance_main
            // в) таблица Balance
            // Они не входят в стандартный набор объектов БД Piramida2000
            // В проекте приложены скрипты их создания
            #endregion
            bool result = false;
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.ToggleBalanceSelected";
            cmd.Parameters.AddWithValue("@No", balanceNo);
            SqlParameter outParam = new SqlParameter("@NewState", result);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);
            cmd.UpdatedRowSource = UpdateRowSource.OutputParameters;
            cmd.ExecuteNonQuery();
            cn.Close();
            return result;
        }

        /// <summary>
        /// Поставить или снять все влажки в поле Check таблицы балансов
        /// <param name="setState">Поставить или снять флажок</param>
        /// </summary>
        public void SelectAllBalances(bool setState)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SelectAllBalances";
            cmd.Parameters.AddWithValue("@SetState", (setState) ? "1" : "0");
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        /// <summary>
        /// Меняем название баланса
        /// </summary>
        /// <param name="balanceID">Номер баланса</param>
        /// <param name="newName">Новое название</param>
        /// <param name="writerConnectionString">Строка подключения с правами запуска хранимой процедуры</param>
        public void UpadateName(long balanceID, string newName, string writerConnectionString)
        {
            SqlConnection cn = new SqlConnection(writerConnectionString);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateBalanceTitle";
            cmd.Parameters.AddWithValue("@BalanceNo", balanceID);
            cmd.Parameters.AddWithValue("@NewTitle", newName);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        /// <summary>
        /// Сначала удаляет все слагаемые заданного баланса, затем
        /// заполняет их заново из переданной дататейбл
        /// </summary>
        /// <param name="balanceID">Номер баланса</param>
        /// <param name="newName">Новое название баланса</param>
        /// <param name="details">Набор строк с данными новых слагаемых баланса</param>
        /// <param name="writerConnectionString">Строка подключения с правами выполнения хранимых
        /// процедур</param>
        /// <returns>True если всё прошло успешно. Если была ошибка, то откатываются все изменения и 
        /// возвращается false</returns>
        public bool UpdateBalanceDetails(long balanceID, string newName, DataTable details, string writerConnectionString)
        {
            bool result = true;
            SqlTransaction tran;
            SqlConnection cn = new SqlConnection(writerConnectionString);
            cn.Open();
            tran = cn.BeginTransaction("BalanceUpdate");
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateBalanceTitle";
            cmd.Transaction = tran;
            cmd.Parameters.AddWithValue("@BalanceNo", balanceID);
            cmd.Parameters.AddWithValue("@NewTitle", newName);
            try
            {
                cmd.ExecuteNonQuery(); // Меняем название балнса
                cmd.Parameters.Clear();
                cmd.CommandText = "DeleteBalanceDetails";
                cmd.Parameters.AddWithValue("@BalanceNo", balanceID);
                int rowsDeleted = cmd.ExecuteNonQuery(); // Удаляем старые слагаемые
                cmd.CommandText = "AddBalanceDetail";
                cmd.Parameters.Clear();
                SqlParameter param = new SqlParameter("@BalanceNo", balanceID);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@Sign", SqlDbType.SmallInt);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@Object", SqlDbType.Int);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@Item", SqlDbType.Int);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@Parnumber", SqlDbType.SmallInt);
                cmd.Parameters.Add(param);
                foreach (DataRow row in details.Rows)
                {
                    cmd.Parameters["@Sign"].Value = (Int16)row[0];
                    cmd.Parameters["@Object"].Value = (int)row[1];
                    cmd.Parameters["@Item"].Value = (int)row[2];
                    cmd.Parameters["@Parnumber"].Value = (Int16)row[3];
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                tran.Rollback();
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                return false;
            }
            tran.Commit();
            if (cn.State == ConnectionState.Open)
                cn.Close();
            return result;
        }

        /// <summary>
        /// Создаёт новый баланс с заглушкой вместо названия
        /// </summary>
        /// <param name="writerConnectionString">Строка подключения с правами выполнения хранимой процедуры</param>
        /// <returns>Значение поля [ID] созданной строки</returns>
        public long CreateBalance(string writerConnectionString)
        {
            long result = -1;
            SqlConnection cn = new SqlConnection(writerConnectionString);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AddBalance";
            cmd.Parameters.AddWithValue("@Title", "Введите название баланса");
            SqlParameter param = new SqlParameter("@NewID",SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
            cmd.UpdatedRowSource = UpdateRowSource.OutputParameters;
            cmd.ExecuteNonQuery();
            result = (int)cmd.Parameters["@NewID"].Value;
            cn.Close();
            return result;
        }

        /// <summary>
        /// Каскадное удаление баланса вместе с его составляющими
        /// </summary>
        /// <param name="balanceNo">Номер баланса</param>
        /// <param name="writerConnectionString">Строка подключения с правами выполнения хранимой процедуры</param>
        /// <returns>true если всё прошло успешно</returns>
        public bool DeleteBalance(long balanceNo,string writerConnectionString)
        {
            bool result = true;
            int rowsDeleted;
            SqlConnection cn = new SqlConnection(writerConnectionString);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteBalance";
            cmd.Parameters.AddWithValue("@BalanceNo", balanceNo);
            try
            {
                rowsDeleted = cmd.ExecuteNonQuery();
                Console.WriteLine("Delete balance: {0} row(s)", rowsDeleted);
            }
            catch
            {
                result = false;
            }
            finally
            {
                cn.Close();
            }
            return result;
        }

        #endregion

        #region Поиски

        /// <summary>
        /// Ищет устройство по коду и возвращает имя
        /// </summary>
        /// <param name="deviceCode"></param>
        /// <returns>Название устройства</returns>
        public string FindByCode(long deviceCode)
        {
            string result;
            StringBuilder sql = new StringBuilder();
            sql.Append("select devices.name devname ");
            sql.Append("from devices ");
            sql.AppendFormat("where devices.code={0}", deviceCode);
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = sql.ToString();
            try
            {
                result = cmd.ExecuteScalar().ToString();
            }
            catch
            {
                result = "Не найдено";
            }
            if (cn.State == ConnectionState.Open)
                cn.Close();
            return result;
        }

        /// <summary>
        /// Ищет совпадения имён в таблице каналов и возвращает список найденных
        /// </summary>
        /// <param name="lookupString">Строка поиска</param>
        /// <param name="exact">Флаг, указывающий на поиск точного совпадения</param>
        /// <returns>Список каналов</returns>
        public List<Sensor> FindByItemName(string lookupString, bool exact)
        {
            Sensor s;
            List<Sensor> result = new List<Sensor>();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT Devices.Code DevCode, Devices.Name DevName, ");
            sql.Append("Sensors.Code SensorCode, Sensors.Name ");
            sql.Append("FROM Devices INNER JOIN Sensors ON Devices.ID=Sensors.StationID ");
            if (exact)
                sql.AppendFormat("WHERE Sensors.Name='{0}'", lookupString);
            else
                sql.AppendFormat("WHERE Sensors.Name LIKE '%{0}%'", lookupString);
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = sql.ToString();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                s = new Sensor();
                s.DeviceCode = dr.GetInt32(0);
                s.DeviceName = dr.GetString(1);
                s.SensorCode = dr.GetInt32(2);
                s.SensorName = dr.GetString(3);
                result.Add(s);
            }
            dr.Close();
            cn.Close();
            if (result.Count == 0)
            {
                s = new Sensor();
                s.DeviceCode = -1;
                s.DeviceName = "Не найдено";
                result.Add(s);
            }
            return result;
        }

        /// <summary>
        /// Ищет совпадения имён в таблице устройств и возвращает список найденных
        /// </summary>
        /// <param name="lookupString">Строка поиска</param>
        /// <param name="exact">Флаг, указывающий на поиск точного совпадения</param>
        /// <returns>Список устройств</returns>
        public List<Sensor> FindByDeviceName(string lookupString, bool exact)
        {
            Sensor s;
            List<Sensor> result = new List<Sensor>();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT Devices.Code DevCode, Devices.Name DevName ");
            sql.Append("FROM Devices ");
            if (exact)
                sql.AppendFormat("WHERE Name='{0}'", lookupString);
            else
                sql.AppendFormat("WHERE Name LIKE '%{0}%'", lookupString);
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = sql.ToString();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                s = new Sensor();
                s.DeviceCode = dr.GetInt32(0);
                s.DeviceName = dr.GetString(1);
                result.Add(s);
            }
            dr.Close();
            cn.Close();
            if (result.Count == 0)
            {
                s = new Sensor();
                s.DeviceCode = -1;
                s.DeviceName = "Не найдено";
                result.Add(s);
            }
            return result;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Возвращает плоский список ID всех вложенных папок для заданной папки
        /// </summary>
        /// <param name="folderID"></param>
        /// <returns></returns>
        private List<long> GetChildFolders(long folderID)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmdFolders;
            SqlDataReader drFolders;
            List<long> result = new List<long>();
            long currentResult;
            string sql = string.Format("SELECT ID FROM Folders WHERE ParentID={0}", folderID);
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmdFolders = cn.CreateCommand(); 
            cmdFolders.CommandText = sql;
            drFolders = cmdFolders.ExecuteReader();
            while (drFolders.Read())
            {
                currentResult = drFolders.GetInt32(0);
                if (currentResult != folderID)
                {
                    result.Add(currentResult);
                    result.AddRange(GetChildFolders(currentResult));
                }
            }
            drFolders.Close();
            cn.Close();
            return result;
        }

        /// <summary>
        /// Возвращает получасовку в формате "ЧЧ:мм" по её номеру
        /// </summary>
        /// <param name="number">номер получасовки</param>
        /// <returns>получаосвку в формате "ЧЧ:мм"</returns>
        private string GetTime(int number)
        {
            string result;
            result = (number / 2).ToString("00") + ":" + ((number % 2) * 30).ToString("00");
            return result;
        }
        #endregion
    }
}
