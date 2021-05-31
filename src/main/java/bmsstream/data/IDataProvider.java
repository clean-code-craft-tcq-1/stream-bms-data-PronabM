package bmsstream.data;

public interface IDataProvider {
	static final String EOF = "###";
	
	public void setParam(String param);
	public String getNext();
}
