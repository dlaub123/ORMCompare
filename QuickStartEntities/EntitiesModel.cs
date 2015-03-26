﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ContextGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using QuickStartEntities;

namespace QuickStartEntities	
{
	public partial class QuickStartEntities : OpenAccessContext, IQuickStartEntitiesUnitOfWork
	{
		private static string connectionStringName = @"QuickStartDBConnection";
			
		private static BackendConfiguration backend = GetBackendConfiguration();
				
		private static MetadataSource metadataSource = XmlMetadataSource.FromAssemblyResource("EntitiesModel.rlinq");
		
		public QuickStartEntities()
			:base(connectionStringName, backend, metadataSource)
		{ }
		
		public QuickStartEntities(string connection)
			:base(connection, backend, metadataSource)
		{ }
		
		public QuickStartEntities(BackendConfiguration backendConfiguration)
			:base(connectionStringName, backendConfiguration, metadataSource)
		{ }
			
		public QuickStartEntities(string connection, MetadataSource metadataSource)
			:base(connection, backend, metadataSource)
		{ }
		
		public QuickStartEntities(string connection, BackendConfiguration backendConfiguration, MetadataSource metadataSource)
			:base(connection, backendConfiguration, metadataSource)
		{ }
			
		public IQueryable<Customer> Customers 
		{
			get
			{
				return this.GetAll<Customer>();
			}
		}
		
		public static BackendConfiguration GetBackendConfiguration()
		{
			BackendConfiguration backend = new BackendConfiguration();
			backend.Backend = "MsSql";
			backend.ProviderName = "System.Data.SqlClient";
		
			CustomizeBackendConfiguration(ref backend);
		
			return backend;
		}
		
		/// <summary>
		/// Allows you to customize the BackendConfiguration of QuickStartEntities.
		/// </summary>
		/// <param name="config">The BackendConfiguration of QuickStartEntities.</param>
		static partial void CustomizeBackendConfiguration(ref BackendConfiguration config);
		
	}
	
	public interface IQuickStartEntitiesUnitOfWork : IUnitOfWork
	{
		IQueryable<Customer> Customers
		{
			get;
		}
	}
}
#pragma warning restore 1591
