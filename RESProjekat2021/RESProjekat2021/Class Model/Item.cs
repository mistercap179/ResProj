///////////////////////////////////////////////////////////
//  Item.cs
//  Implementation of the Class Item
//  Generated by Enterprise Architect
//  Created on:      31-maj-2021 17:53:21
//  Original author: AB
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Item {

	private CodeEnum code;
	private int value;

	public Item(){}

	~Item(){}

	public CodeEnum Code { get => code; set => code = value; }
	public int Value { get => value; set => this.value = value; }


    public Item(int code, int value)
    {
        if (code < 1 || code > 8)
        {
            throw new ArgumentException("Code mora biti izmedju 1 i 8");
        }
        if ((code == 2 && value < 0) || (code == 2 && value > 1))
        {
            throw new ArgumentException("CODE_DIGITAL moze imati samo vrijednost 0 ili 1");
        }
        if ((value < 0 || value > 1000) && code != 2)
        {
            throw new ArgumentException("Vrijednost van opsega!");
        }

        this.Code = (CodeEnum)code;
        this.Value = value;
    }


}//end Item