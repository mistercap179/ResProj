///////////////////////////////////////////////////////////
//  CollectionDescription.cs
//  Implementation of the Class CollectionDescription
//  Generated by Enterprise Architect
//  Created on:      31-maj-2021 17:53:21
//  Original author: AB
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class CollectionDescription {

	private HistoricalCollection historicalCollection;
	private int iD;
	private int dataSet;

	
	public int ID { get => iD; set => iD = value; }
	public int DataSet { get => dataSet; set => dataSet = value; }
	public HistoricalCollection HistoricalCollection { get => historicalCollection; set => historicalCollection = value; }

	public CollectionDescription()
	{
		this.iD = 1;
		this.dataSet = 1;
		this.historicalCollection = new HistoricalCollection();
	}
	
	~CollectionDescription(){

	}

}//end CollectionDescription