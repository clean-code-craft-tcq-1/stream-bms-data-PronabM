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
	
	public static List<String> stream() {
		List<String> buffer = new ArrayList<String>();
		while(true)
		{	
			String next = provider.getNext();
			if(next==null)
				break;
			buffer.add(sendToConsole(next));
		}
		sendToConsole(IDataProvider.EOF);
		return buffer;
	}

	private static String sendToConsole(String text) {
		System.out.println(text);
		return text;
	}

}
