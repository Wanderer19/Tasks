package Reader;

import java.io.*;
import java.util.*;


public class Reader {
	private Scanner in;
	
	public String GetInputLine(InputStream inputStream, String encoding) throws IOException{
		in = new Scanner(new BufferedReader(new InputStreamReader(inputStream, encoding)));
		
		String line = in.nextLine();
		return line;
	}
		
	
	public ArrayList<String>ReadFile(String file, String encoding) throws FileNotFoundException, IOException{
		
		ArrayList<String> inputLines = new ArrayList<String>();
		
		in  = new Scanner(new BufferedReader(new InputStreamReader(new FileInputStream(file), encoding)));
		
		
		while (in.hasNext()){
			inputLines.add(in.nextLine());
		}
		
		return inputLines;
	}
	
	public HashMap<String, String>GetInputParameters(InputStream inputStream, String encoding) throws IOException{
		HashMap<String, String> inputData = new HashMap<String, String>();
		
		inputData.put("inputFileName", GetInputLine(inputStream, encoding));
		inputData.put("inputEncoding", GetInputLine(inputStream, encoding));
		
		inputData.put("outputFileName", GetInputLine(inputStream, encoding));
		inputData.put("outputEncoding", GetInputLine(inputStream, encoding));
		
	
		
		return inputData;
	}
}
