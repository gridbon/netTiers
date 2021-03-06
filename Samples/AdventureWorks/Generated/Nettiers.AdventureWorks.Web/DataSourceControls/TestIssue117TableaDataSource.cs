﻿#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;
using Nettiers.AdventureWorks.Data.Bases;
using Nettiers.AdventureWorks.Services;
#endregion

namespace Nettiers.AdventureWorks.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.TestIssue117TableaProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TestIssue117TableaDataSourceDesigner))]
	public class TestIssue117TableaDataSource : ProviderDataSource<TestIssue117Tablea, TestIssue117TableaKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestIssue117TableaDataSource class.
		/// </summary>
		public TestIssue117TableaDataSource() : base(new TestIssue117TableaService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TestIssue117TableaDataSourceView used by the TestIssue117TableaDataSource.
		/// </summary>
		protected TestIssue117TableaDataSourceView TestIssue117TableaView
		{
			get { return ( View as TestIssue117TableaDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TestIssue117TableaDataSource control invokes to retrieve data.
		/// </summary>
		public TestIssue117TableaSelectMethod SelectMethod
		{
			get
			{
				TestIssue117TableaSelectMethod selectMethod = TestIssue117TableaSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TestIssue117TableaSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TestIssue117TableaDataSourceView class that is to be
		/// used by the TestIssue117TableaDataSource.
		/// </summary>
		/// <returns>An instance of the TestIssue117TableaDataSourceView class.</returns>
		protected override BaseDataSourceView<TestIssue117Tablea, TestIssue117TableaKey> GetNewDataSourceView()
		{
			return new TestIssue117TableaDataSourceView(this, DefaultViewName);
		}
		
		/// <summary>
        /// Creates a cache hashing key based on the startIndex, pageSize and the SelectMethod being used.
        /// </summary>
        /// <param name="startIndex">The current start row index.</param>
        /// <param name="pageSize">The current page size.</param>
        /// <returns>A string that can be used as a key for caching purposes.</returns>
		protected override string CacheHashKey(int startIndex, int pageSize)
        {
			return String.Format("{0}:{1}:{2}", SelectMethod, startIndex, pageSize);
        }
		
		#endregion Methods
	}
	
	/// <summary>
	/// Supports the TestIssue117TableaDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TestIssue117TableaDataSourceView : ProviderDataSourceView<TestIssue117Tablea, TestIssue117TableaKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TestIssue117TableaDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TestIssue117TableaDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TestIssue117TableaDataSourceView(TestIssue117TableaDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TestIssue117TableaDataSource TestIssue117TableaOwner
		{
			get { return Owner as TestIssue117TableaDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TestIssue117TableaSelectMethod SelectMethod
		{
			get { return TestIssue117TableaOwner.SelectMethod; }
			set { TestIssue117TableaOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TestIssue117TableaService TestIssue117TableaProvider
		{
			get { return Provider as TestIssue117TableaService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TestIssue117Tablea> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TestIssue117Tablea> results = null;
			TestIssue117Tablea item;
			count = 0;
			
			System.Int32 _testIssue117TableAid;
			System.Int32 _testIssue117TableBid;

			switch ( SelectMethod )
			{
				case TestIssue117TableaSelectMethod.Get:
					TestIssue117TableaKey entityKey  = new TestIssue117TableaKey();
					entityKey.Load(values);
					item = TestIssue117TableaProvider.Get(entityKey);
					results = new TList<TestIssue117Tablea>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TestIssue117TableaSelectMethod.GetAll:
                    results = TestIssue117TableaProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TestIssue117TableaSelectMethod.GetPaged:
					results = TestIssue117TableaProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TestIssue117TableaSelectMethod.Find:
					if ( FilterParameters != null )
						results = TestIssue117TableaProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TestIssue117TableaProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TestIssue117TableaSelectMethod.GetByTestIssue117TableAid:
					_testIssue117TableAid = ( values["TestIssue117TableAid"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TestIssue117TableAid"], typeof(System.Int32)) : (int)0;
					item = TestIssue117TableaProvider.GetByTestIssue117TableAid(_testIssue117TableAid);
					results = new TList<TestIssue117Tablea>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				// M:M
				case TestIssue117TableaSelectMethod.GetByTestIssue117TableBidFromTestIssue117Tablec:
					_testIssue117TableBid = ( values["TestIssue117TableBid"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TestIssue117TableBid"], typeof(System.Int32)) : (int)0;
					results = TestIssue117TableaProvider.GetByTestIssue117TableBidFromTestIssue117Tablec(_testIssue117TableBid, this.StartIndex, this.PageSize, out count);
					break;
				// Custom
				default:
					break;
			}

			if ( results != null && count < 1 )
			{
				count = results.Count;

				if ( !String.IsNullOrEmpty(CustomMethodRecordCountParamName) )
				{
					object objCustomCount = EntityUtil.ChangeType(customOutput[CustomMethodRecordCountParamName], typeof(Int32));
					
					if ( objCustomCount != null )
					{
						count = (int) objCustomCount;
					}
				}
			}
			
			return results;
		}
		
		/// <summary>
		/// Gets the values of any supplied parameters for internal caching.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		protected override void GetSelectParameters(IDictionary values)
		{
			if ( SelectMethod == TestIssue117TableaSelectMethod.Get || SelectMethod == TestIssue117TableaSelectMethod.GetByTestIssue117TableAid )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				TestIssue117Tablea entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TestIssue117TableaProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
					// set loaded flag
					IsDeepLoaded = true;
				}
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation on the specified entity collection.
		/// </summary>
		/// <param name="entityList"></param>
		/// <param name="properties"></param>
		internal override void DeepLoad(TList<TestIssue117Tablea> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TestIssue117TableaProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TestIssue117TableaDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TestIssue117TableaDataSource class.
	/// </summary>
	public class TestIssue117TableaDataSourceDesigner : ProviderDataSourceDesigner<TestIssue117Tablea, TestIssue117TableaKey>
	{
		/// <summary>
		/// Initializes a new instance of the TestIssue117TableaDataSourceDesigner class.
		/// </summary>
		public TestIssue117TableaDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TestIssue117TableaSelectMethod SelectMethod
		{
			get { return ((TestIssue117TableaDataSource) DataSource).SelectMethod; }
			set { SetPropertyValue("SelectMethod", value); }
		}

		/// <summary>Gets the designer action list collection for this designer.</summary>
		/// <returns>The <see cref="T:System.ComponentModel.Design.DesignerActionListCollection"/>
		/// associated with this designer.</returns>
		public override DesignerActionListCollection ActionLists
		{
			get
			{
				DesignerActionListCollection actions = new DesignerActionListCollection();
				actions.Add(new TestIssue117TableaDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TestIssue117TableaDataSourceActionList

	/// <summary>
	/// Supports the TestIssue117TableaDataSourceDesigner class.
	/// </summary>
	internal class TestIssue117TableaDataSourceActionList : DesignerActionList
	{
		private TestIssue117TableaDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TestIssue117TableaDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TestIssue117TableaDataSourceActionList(TestIssue117TableaDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TestIssue117TableaSelectMethod SelectMethod
		{
			get { return _designer.SelectMethod; }
			set { _designer.SelectMethod = value; }
		}

		/// <summary>
		/// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// objects contained in the list.
		/// </summary>
		/// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// array that contains the items in this list.</returns>
		public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection items = new DesignerActionItemCollection();
			items.Add(new DesignerActionPropertyItem("SelectMethod", "Select Method", "Methods"));
			return items;
		}
	}

	#endregion TestIssue117TableaDataSourceActionList
	
	#endregion TestIssue117TableaDataSourceDesigner
	
	#region TestIssue117TableaSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TestIssue117TableaDataSource.SelectMethod property.
	/// </summary>
	public enum TestIssue117TableaSelectMethod
	{
		/// <summary>
		/// Represents the Get method.
		/// </summary>
		Get,
		/// <summary>
		/// Represents the GetAll method.
		/// </summary>
		GetAll,
		/// <summary>
		/// Represents the GetPaged method.
		/// </summary>
		GetPaged,
		/// <summary>
		/// Represents the Find method.
		/// </summary>
		Find,
		/// <summary>
		/// Represents the GetByTestIssue117TableAid method.
		/// </summary>
		GetByTestIssue117TableAid,
		/// <summary>
		/// Represents the GetByTestIssue117TableBidFromTestIssue117Tablec method.
		/// </summary>
		GetByTestIssue117TableBidFromTestIssue117Tablec
	}
	
	#endregion TestIssue117TableaSelectMethod

	#region TestIssue117TableaFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestIssue117Tablea"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestIssue117TableaFilter : SqlFilter<TestIssue117TableaColumn>
	{
	}
	
	#endregion TestIssue117TableaFilter

	#region TestIssue117TableaExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TestIssue117Tablea"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestIssue117TableaExpressionBuilder : SqlExpressionBuilder<TestIssue117TableaColumn>
	{
	}
	
	#endregion TestIssue117TableaExpressionBuilder	

	#region TestIssue117TableaProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TestIssue117TableaChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TestIssue117Tablea"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TestIssue117TableaProperty : ChildEntityProperty<TestIssue117TableaChildEntityTypes>
	{
	}
	
	#endregion TestIssue117TableaProperty
}

