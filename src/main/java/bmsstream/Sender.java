package bmsstream;

import bmsstream.data.DataProviderResolver;

public class Sender
{
    public static void main(String[] args)
    {
    	if(args.length > 1)
    		SenderService.setProvider(DataProviderResolver.resolve(args[0], args[1]));
        else
    	    SenderService.setProvider(DataProviderResolver.resolve("R", "10"));
    	SenderService.stream();
    }
}
