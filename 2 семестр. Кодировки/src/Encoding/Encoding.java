package Encoding;

import java.io.*;
import java.nio.charset.Charset;
import java.util.*;

import Reader.Reader;

public class Encoding {

	private Reader reader;
	private  ArrayList<String>  inputLines;
	
	public Encoding(){
		reader = new Reader();
		inputLines = new ArrayList<String>();
	}
	
	public void WriteToFile(ArrayList<String> inputLines, String file, String encoding) throws UnsupportedEncodingException, FileNotFoundException{
		PrintWriter out = new PrintWriter( new OutputStreamWriter(new FileOutputStream(file), encoding), true);
		
		for (String line : inputLines){
			String outputLine = new String(line.getBytes(), encoding);
			out.println(outputLine);
		}
		
		out.flush();
	}
	
	public static void main(String [] args) throws IOException{
		try{
			
		
			Encoding encoding = new Encoding();
		
			HashMap<String, String> inputData = encoding.reader.GetInputParameters(System.in,  System.getProperty("file.encoding"));
			encoding.inputLines = encoding.reader.ReadFile(inputData.get("inputFileName"), inputData.get("inputEncoding"));
			
			encoding.WriteToFile(encoding.inputLines, inputData.get("outputFileName"), inputData.get("outputEncoding"));
			
			System.out.println("Конец");
			
	
		}catch(Exception ex){
			System.out.println("Hi" + ex.getMessage());
		}
		
	}
}
