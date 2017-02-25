using System;
using System.Data.SQLite;
using System.Data;
using System.Configuration;

namespace Mp3Encode.Data
{
    public class UserSettings : IDisposable
    {
        SQLiteConnection _connection = null;
        SQLiteDataAdapter _recordingSettingAdapter = null;

        public UserSettings()
        {
            _connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["UserSettings"].ConnectionString);
            _connection.Open();

            _recordingSettingAdapter = new SQLiteDataAdapter("select * from RecordingSettings order by name", _connection);
            _recordingSettingAdapter.UpdateCommand = new SQLiteCommand(
                    @"update RecordingSettings
                      set Name = @Name,
                          QualityType = @QualityType,
                          QualityLevel = @QualityLevel,
                          SamplingRate = @SamplingRate,
                          MonoMode = @MonoMode,
                          Artist = @Artist,
                          Title = @Title,
                          Album = @Album,
                          Genre = @Genre,
                          Comment = @Comment
                    where Id = @Id", _connection);

            _recordingSettingAdapter.InsertCommand = new SQLiteCommand(
                @"insert into RecordingSettings
                  (Name, QualityType, QualityLevel, SamplingRate, MonoMode, Artist, Title, Album, Genre, Comment)
                  values
                  (@Name, @QualityType, @QualityLevel, @SamplingRate, @MonoMode, @Artist, @Title, @Album, @Genre, @Comment)",
                _connection);

            _recordingSettingAdapter.DeleteCommand = new SQLiteCommand(
                @"delete from RecordingSettings where Id = @Id", _connection);

            DataTable dt = new DataTable();
            _recordingSettingAdapter.FillSchema(dt, SchemaType.Source);
            foreach (DataColumn column in dt.Columns)
            {
                var param = new SQLiteParameter();
                param.ParameterName = "@" + column.ColumnName;
                param.SourceColumn = column.ColumnName;

                _recordingSettingAdapter.InsertCommand.Parameters.Add(param);
                _recordingSettingAdapter.UpdateCommand.Parameters.Add(param);
            }

            _recordingSettingAdapter.DeleteCommand.Parameters.Add(new SQLiteParameter { ParameterName = "@Id", SourceColumn = "Id" });
        }

        public DataTable GetAllRecordingSettings()
        {
            DataTable dt = new DataTable("RecordingSettings");
            _recordingSettingAdapter.Fill(dt);
            dt.Columns["Id"].AutoIncrement = true;
            return dt;
        }

        public void SaveRecordingSettings(DataTable recordingSettings)
        {
            _recordingSettingAdapter.Update(recordingSettings);
        }

        public void Dispose()
        {
            if (_recordingSettingAdapter != null)
            {
                _recordingSettingAdapter.Dispose();
                _recordingSettingAdapter = null;
            }

            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
