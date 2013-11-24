use Build;
use Test::Simple tests => 14;
	
my %dictionary;
@dictionary{("aaa","aab","aac","aad","abc","bbb","ccc","abb","ddd","aa","ab","ac","ba","ad","bc","a","b","c","d")}=();
my @alphabet=("a","b","c","d");
    
ok(defined(${form(\%dictionary,"aaa","bbb",\@alphabet)}[0]));
ok(!defined(${form(\%dictionary,"","",\@alphabet)}[0]));
ok(defined(${form(\%dictionary,"a","d",\@alphabet)}[0]));
ok(defined(${form(\%dictionary,"aa","bc",\@alphabet)}[0]));
ok(!defined(${form(\%dictionary,"e","k",\@alphabet)}[0]));
ok(!defined(${form(\%dictionary,"e","k",\@alphabet)}[0]));
ok(!defined(${form(\%dictionary,"e","aaa",\@alphabet)}[0]));
ok(!defined(${form(\%dictionary,"aaa","b",\@alphabet)}[0]));
ok(defined(${form(\%dictionary,"aaa","aaa",\@alphabet)}[0]));
ok(!defined(${form(\%dictionary,"aaa","ttt",\@alphabet)}[0]));
ok(check("aaa","bbb",\%dictionary,form(\%dictionary,"aaa","bbb",\@alphabet)));
ok(check("a","d",\%dictionary,form(\%dictionary,"a","d",\@alphabet)));
ok(check("aaa","aaa",\%dictionary,form(\%dictionary,"aaa","aaa",\@alphabet)));
ok(check("aa","bc",\%dictionary,form(\%dictionary,"aa","bc",\@alphabet)));


sub check{
    my ($Initial,$Target,$dictionary,$chain)=@_;
	  
	return 0 if ( ($$chain[0] ne $Initial) || ($$chain[-1] ne $Target) );
	  
	for my $word ( @$chain ){
	     return 0 unless ( exists($dictionary->{$word}) );
	}
	  
	for ( my $i=0 ;$i<scalar(@$chain)-1; $i++ ){
	     return 0 unless ( letter($$chain[$i],$$chain[$i+1]) );
	}
	  
	return 1;
}
	 
sub letter{
	 my ($j,$Initial)=@_;
     my $res=0;
         
	for ( my $k=0 ;$k<length($Initial); $k++ ){      
	    if ( substr($j,$k,1) ne substr($Initial,$k,1) ){
	         $res++;
		}
			
		return 0 if ( $res>1 );
	}
	
    return $res;
}