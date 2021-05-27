package bmsstream;

import java.util.ArrayList;
import java.util.List;

import bmsstream.data.IDataProvider;
import bmsstream.data.RandomDataProvider;

public class SenderService {
	
	private static IDataProvider provider = new RandomDataProvider();
	
	public static void setProvider(IDataProvider provider) {
		if(provider != null)
			SenderService.provider = provider;
	}
	
	public static List<String> stream(int nline) {
		List<String> buffer = new ArrayList<String>();
		while(nline-->0)
			buffer.add(sendToConsole(provider.getNext()));
		sendToConsole(IDataProvider.EOF);
		return buffer;
	}

	private static String sendToConsole(String text) {
		System.out.println(text);
		return text;
	}

}
