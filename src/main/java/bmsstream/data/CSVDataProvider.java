package bmsstream.data;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;

public class CSVDataProvider implements IDataProvider {

	private BufferedReader br;
	
	@Override
	public void setParam(String param) {
		try {br = new BufferedReader(new FileReader(param));} 
		catch (FileNotFoundException e) {}
	}
	
	@Override
	public String getNext() {
		String line = null;
		try {line = (br!=null) ? br.readLine():null;} 
		catch (IOException e) {}
		return line;
	}

}
