using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Answer
{
  public class AnswerModel
    {
      public AnswerModel()
      { }

      #region 回复表Model
      private int _answerid;
      private int _questionid;
      private string _content;
      private string _name;
      private string _business;
      private DateTime _adddate;
      private string _title;
      private int _state;
      /// <summary>
      /// 回复表
      /// </summary>
      public int AnswerId
      {
          set { _answerid = value; }
          get { return _answerid; }
      }
      /// <summary>
      /// 
      /// </summary>
      public int QuestionId
      {
          set { _questionid = value; }
          get { return _questionid; }
      }
      /// <summary>
      /// 
      /// </summary>
      public string Content
      {
          set { _content = value; }
          get { return _content; }
      }
      /// <summary>
      /// 
      /// </summary>
      public string Name
      {
          set { _name = value; }
          get { return _name; }
      }
      /// <summary>
      /// 
      /// </summary>
      public string Business
      {
          set { _business = value; }
          get { return _business; }
      }
      /// <summary>
      /// 
      /// </summary>
      public DateTime AddDate
      {
          set { _adddate = value; }
          get { return _adddate; }
      }
      /// <summary>
      /// 
      /// </summary>
      public string Title
      {
          set { _title = value; }
          get { return _title; }
      }
      /// <summary>
      /// 
      /// </summary>
      public int State
      {
          set { _state = value; }
          get { return _state; }
      }
      #endregion Model
    }
}
