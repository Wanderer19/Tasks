use Sorts1;
use Test::Simple tests => 16;

my @sorts=('select_sort','bubble_sort','insert_sort','pyramid_sort','quick_sort','shell_sort','merge_sort','function_sort');
	
for my $x ( @sorts ){
	my $current_sorting=\&$x;
    ok ( check(&{$current_sorting}([(1,0,-10,5,6)x10],\&less), \&less ),"Resulting array is sorted in ascending, $x" );
}
		
for $x ( @sorts ){
	$current_sorting=\&$x;
    ok ( check(&{$current_sorting}([(1,0,-10,5,6)x10],\&more), \&more ),"Resulting array is sorted in descending order,  $x" );
}
    
sub check{
    my ($a,$comparator)=@_;
	 
	for ( my $i=0 ;$i<scalar(@$a)-1; $i++ ){
	    return 0 if ( &{$comparator}($$a[$i+1],$$a[$i]) );
	}
	
	return 1;
}
