package bmsstream;

import bmsstream.data.RandomDataProvider;

public class Sender
{
    public static void main( String[] args )
    {
    	SenderService.setProvider(new RandomDataProvider());
    	SenderService.stream(500);
    }
}
