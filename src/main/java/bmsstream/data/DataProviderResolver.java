package bmsstream.data;

import java.util.HashMap;
import java.util.Map;

public class DataProviderResolver {
	private static final Map<String, IDataProvider> REPOSITORY;
	
	static {
		REPOSITORY = new HashMap<String, IDataProvider>();
		REPOSITORY.put("F", new CSVDataProvider());
		REPOSITORY.put("R", new RandomDataProvider());
	}
	
	public static IDataProvider resolve(String type, String param) {
		IDataProvider provider = REPOSITORY.get(type);
		provider.setParam(param);
		return provider;
	}
	
}
