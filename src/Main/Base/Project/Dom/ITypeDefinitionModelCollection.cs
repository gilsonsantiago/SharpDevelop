﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.SharpDevelop.Dom
{
	/// <summary>
	/// A collection of type definition models with the ability to look them up by name.
	/// </summary>
	public interface ITypeDefinitionModelCollection : IModelCollection<ITypeDefinitionModel>
	{
		/// <summary>
		/// Gets the type definition model with the specified type name.
		/// Returns null if no such model object exists.
		/// </summary>
		ITypeDefinitionModel this[FullTypeName fullTypeName] { get; }
		
		/// <summary>
		/// Gets the type definition model with the specified type name.
		/// Returns null if no such model object exists.
		/// </summary>
		ITypeDefinitionModel this[TopLevelTypeName topLevelTypeName] { get; }
	}
	
	public interface IMutableTypeDefinitionModelCollection : ITypeDefinitionModelCollection, IList<ITypeDefinitionModel>
	{
		/// <summary>
		/// Updates the collection when the parse information has changed.
		/// </summary>
		void Update(IUnresolvedFile oldFile, IUnresolvedFile newFile);
	}
	
	public sealed class EmptyTypeDefinitionModelCollection : ITypeDefinitionModelCollection
	{
		public static readonly EmptyTypeDefinitionModelCollection Instance = new EmptyTypeDefinitionModelCollection();
		
		event NotifyCollectionChangedEventHandler INotifyCollectionChanged.CollectionChanged {
			add { }
			remove { }
		}
		
		ITypeDefinitionModel ITypeDefinitionModelCollection.this[FullTypeName name] {
			get { return null; }
		}
		
		ITypeDefinitionModel ITypeDefinitionModelCollection.this[TopLevelTypeName name] {
			get { return null; }
		}
		
		ITypeDefinitionModel IReadOnlyList<ITypeDefinitionModel>.this[int index] {
			get {
				throw new ArgumentOutOfRangeException();
			}
		}
		
		int IReadOnlyCollection<ITypeDefinitionModel>.Count {
			get { return 0; }
		}
		
		IEnumerator<ITypeDefinitionModel> IEnumerable<ITypeDefinitionModel>.GetEnumerator()
		{
			return Enumerable.Empty<ITypeDefinitionModel>().GetEnumerator();
		}
		
		IEnumerator IEnumerable.GetEnumerator()
		{
			return Enumerable.Empty<ITypeDefinitionModel>().GetEnumerator();
		}
	}
}