package bmsstream;

import static bmsstream.data.RandomDataProvider.*;
import static org.junit.Assert.assertTrue;

import java.util.List;
import org.junit.Test;

import bmsstream.data.RandomDataProvider;

public class SenderSeviceTest 
{
    @Test
    public void whenLineParamZero_expectEmptyStream()
    {
        assertTrue( SenderService.stream(0).size() == 0 );
    }
    
    @Test
    public void whenLineParamNegative_expectEmptyStream()
    {
        assertTrue( SenderService.stream(-1).size() == 0 );
    }
    
    @Test
    public void whenLineParamPositive_expectSameStreamSize()
    {
    	int nline = 10;
        assertTrue( SenderService.stream(nline).size() == nline );
    }
    
    @Test
    public void whenRandomProvider_expectValuesWithinRange()
    {
    	int nline = 10;
    	SenderService.setProvider(new RandomDataProvider());
        List<String> result = SenderService.stream(nline);
        for(String line : result)
        {
        	String[] params = line.split(DELIMITER);
        	Integer temp = Integer.parseInt(params[0]);
        	Integer soc = Integer.parseInt(params[1]);
        	Float cr = Float.parseFloat(params[2]);
        	assertTrue(checkInRange(MIN_TEMP,temp,MAX_TEMP));
        	assertTrue(checkInRange(MIN_SOC,soc,MAX_SOC));
        	assertTrue(checkInRange(MIN_CR,cr,MAX_CR));
        }
    }

	private boolean checkInRange(Float min, Float value, Float max) {
		return min <= value && value <= max;
	}

	private boolean checkInRange(Integer min, Integer value, Integer max) {
		return min <= value && value <= max;
	}   
}
