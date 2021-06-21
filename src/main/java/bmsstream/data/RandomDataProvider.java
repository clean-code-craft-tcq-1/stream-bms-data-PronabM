package bmsstream.data;

import java.util.Random;

public class RandomDataProvider implements IDataProvider {
	
	public final static String DELIMITER = ",";
	public final static Integer MIN_TEMP = 0;
	public final static Integer MAX_TEMP = 45;
	public final static Integer MIN_SOC = 20;
	public final static Integer MAX_SOC = 80;
	public final static Float MIN_CR = 0f;
	public final static Float MAX_CR = 0.8f;
	private Random random = new Random();
	private int nline = 10;
	
	@Override
	public void setParam(String param) {
		try{this.nline = Integer.parseInt(param);}
		catch(Exception e) {}
	}
	
	@Override
	public String getNext() {
		while(this.nline-->0)
			return new StringBuilder()
				.append(getTemp()).append(DELIMITER)
				.append(getSOC()).append(DELIMITER)
				.append(getCR())
				.toString();
		return null;
	}

	private Float getCR() {
		return getRandom(MIN_CR,MAX_CR);
	}

	private Float getRandom(Float min, Float max) {
		return random.nextFloat() * (max - min) + min;
	}
	
	private Integer getRandom(Integer min, Integer max) {
		return random.nextInt(max - min) + min;
	}

	private Integer getSOC() {
		return getRandom(MIN_SOC,MAX_SOC);
	}

	private Integer getTemp() {
		return getRandom(MIN_TEMP,MAX_TEMP);
	}

}
