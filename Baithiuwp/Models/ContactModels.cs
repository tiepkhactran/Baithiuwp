using Baithiuwp.Entity;
using Baithiuwp.Untils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baithiuwp.Models
{
    class ContactModels
    {
            public bool Insert(Contacts contacts)
            {
                try
                {
                    using (var stt = SQLiteUtil.GetIntances().Connection.Prepare("INSERT INTO Note (Name, PhoneNumber) VALUES (?, ?,)"))
                    {
                        stt.Bind(1, contacts.Name);
                        stt.Bind(2, contacts.PhoneNumber);
                        stt.Bind(3, "2010-10-10");
                        stt.Bind(4, "2010-09-09");
                        stt.Step();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                return false;
            }

            public List<Contacts> Select()
            {
                try
                {
                    List<Contacts> lstNote = new List<Contacts>();
                    using (var stt = SQLiteUtil.GetIntances().Connection.Prepare("SELECT * from Note"))
                    {
                        while (stt.Step() == SQLitePCL.SQLiteResult.ROW)
                        {
                            var getNote = new Contacts();
                            getNote.Id = Convert.ToInt32(stt[0]);
                            getNote.Name = (string)stt[1];
                            getNote.PhoneNumber = (string)stt[2];
                            lstNote.Add(getNote);
                        }
                        return lstNote;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }

            public Contacts SelectOneItem(int? id)
            {
                try
                {
                    var getNote = new Contacts();
                    using (var stt = SQLiteUtil.GetIntances().Connection.Prepare("SELECT * from Note Where Id = ?"))
                    {
                        stt.Bind(1, id);
                        if (stt.Step() == SQLitePCL.SQLiteResult.ROW)
                        {
                            getNote.Name = (string)stt[1];
                            getNote.PhoneNumber = (string)stt[2];
                        }
                        return getNote;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }

            public void Update(Contacts note)
            {
                try
                {
                    var getNote = new Contacts();
                    using (var stt = SQLiteUtil.GetIntances()
                        .Connection.Prepare(@"Update Note Set Title = ?, Content = ? Where Id = ?"))
                    {
                        stt.Bind(1, note.Name);
                        stt.Bind(2, note.PhoneNumber);
                        stt.Bind(3, note.Id);
                        stt.Step();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            public void Delete(int id)
            {
                try
                {
                    var getNote = new Contacts();
                    using (var stt = SQLiteUtil.GetIntances()
                        .Connection.Prepare(@"Delete from Note Where Id = ?"))
                    {
                        stt.Bind(1, id);
                        stt.Step();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }


