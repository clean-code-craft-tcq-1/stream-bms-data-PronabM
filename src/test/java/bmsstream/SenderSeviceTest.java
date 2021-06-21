package bmsstream;

import static bmsstream.data.RandomDataProvider.*;
import static org.junit.Assert.assertTrue;

import java.util.List;
import org.junit.Test;

import bmsstream.data.DataProviderResolver;

public class SenderSeviceTest 
{
    @Test
    public void whenLineParamZero_expectEmptyStream()
    {
    	SenderService.setProvider(DataProviderResolver.resolve("R", "0"));
        assertTrue( SenderService.stream().size() == 0 );
    }
    
    @Test
    public void whenLineParamNegative_expectEmptyStream()
    {
    	SenderService.setProvider(DataProviderResolver.resolve("R", "-1"));
        assertTrue( SenderService.stream().size() == 0 );
    }
    
    @Test
    public void whenLineParamPositive_expectSameStreamSize()
    {
    	Integer nline = 10;
    	SenderService.setProvider(DataProviderResolver.resolve("R", nline.toString()));
        assertTrue( SenderService.stream().size() == nline );
    }
    
    @Test
    public void whenRandomProvider_expectValuesWithinRange()
    {
    	Integer nline = 10;
    	SenderService.setProvider(DataProviderResolver.resolve("R", nline.toString()));
        List<String> result = SenderService.stream();
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
    
    @Test
    public void whenCSVProvider_expectSameValues()
    {
    	String path = "src\\main\\java\\bmsstream\\assets\\demo.csv";
    	SenderService.setProvider(DataProviderResolver.resolve("F", path));
        List<String> result = SenderService.stream();
        Integer[] expectedTemp = {18,7,23};
        Integer[] expectedSOC = {67,44,56};
        Float[] expectedCR = {0.3f,0.43f,0.7f};
        for(int i=0; i<result.size();i++)
        {
        	String[] params = result.get(i).split(DELIMITER);
        	Integer temp = Integer.parseInt(params[0]);
        	Integer soc = Integer.parseInt(params[1]);
        	Float cr = Float.parseFloat(params[2]);
        	assertTrue(temp.equals(expectedTemp[i]));
        	assertTrue(soc.equals(expectedSOC[i]));
        	assertTrue(cr.equals(expectedCR[i]));
        }
    }

	private boolean checkInRange(Float min, Float value, Float max) {
		return min <= value && value <= max;
	}

	private boolean checkInRange(Integer min, Integer value, Integer max) {
		return min <= value && value <= max;
	}   
}
